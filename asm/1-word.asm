; ================================== ТЕХНИЧЕСКОЕ ЗАДАНИЕ ==================================
; вариант 112
;
; в исходном массиве переставить элементы так, чтобы они располагались в следующем порядке:
; все отрицательные элементы в порядке возрастания, затем все остальные;

; Элемент исходного массива помещается в массив результата если его значение:                            
; больше среднего арифметического наименьшего и второго элемента исходного массива. 

; Базовый массив - индексная адресация
; Результат - базовая адресация
; ==========================================================================================

.model small
.386

.stack

.const
	ITEM_COUNT EQU 10 		; кол-во элементов в массиве
	ITEM_SIZE EQU 2	  		; размер элемента массива в байтах

.data
	array dw 2, 8, -9, -13, 0, 11, -6, -2, 4, 7
	result dw ITEM_COUNT DUP(0)
	lastNegativeIndex db -1
	
.code

main proc	  
	
	.startup
				
	mov ax, array[ITEM_SIZE] ; сохраняем второй элемент исходного массива в АХ
					  
	; перемещаем все неотрицательные эл-ты направо
	; идём СПРАВА НАЛЕВО, т.к. при этом элементы >= 0 не перемешиваются
	; BX = индекс i-го элемента
	; DX = его значение
	; SI = индекс последнего отрицательного элемента
	mov cx, ITEM_COUNT		
	mov bx, cx			
	dec bx
	imul bx, ITEM_SIZE				
	FIRST_LOOP:
						
		mov dx, array[bx]
		
		; если элемент отрицательный, а индекс последнего отрицательного не установлен
		cmp dx, 0
		jge else_1	; DX >= 0
		cmp lastNegativeIndex, -1
		jne else_1	; lastNegativeIndex != -1
						
			mov lastNegativeIndex, cl		; lastNegativeIndex = cx - 1
			dec lastNegativeIndex
			jmp endif_1
					
		; элемент неотрицательный и до него уже были отрицательные
		; меняем местами и возвращаемся назад
		else_1:
		cmp dx, 0
		jl endif_1	; DX < 0
		cmp lastNegativeIndex, -1
		jz endif_1	; lastNegativeIndex == -1
		
			movzx si, lastNegativeIndex	; SI = индекс элемента lastNegativeIndex
			imul si, ITEM_SIZE
							
			xchg dx, array[si]		; dx = array[lastNegativeIndex], array[lastNegativeIndex] = array[i]
			mov array[bx], dx		; array[i] = dx
								
			; возвращаемся на array[lastNegativeIndex]
			mov cl, lastNegativeIndex
			mov bx, cx				
			imul bx, ITEM_SIZE
			inc cx							
								
			mov lastNegativeIndex, -1	; сброс	
							
		endif_1:
						
		sub bx, ITEM_SIZE 		
				
	loop FIRST_LOOP
				
	; теперь сортируем отрицательные элементы
	; BX = адрес i-го элемента
	; SI = адрес j-го элемента
	; DX = минимальный элемент для сортировки
	; DI = его адрес
	mov cl, lastNegativeIndex
	inc cx
	xor bx, bx
	SECOND_LOOP:
	
		mov dx, array[bx] 	; min = array[i]
		mov di, bx			; minIndex = i
			
		; for (int j = i; j <= lastNegativeIndex; j++)
		push cx			; сохраняем счётчик в стеке
		mov si, bx		; SI = j = i
		INNER_LOOP:
			
			cmp array[si], dx		
			jge inner_min_check	; 
				
				mov dx, array[si]	; DX = array[j]
				mov di, si			; DI = j
			
			inner_min_check:
			
			add si, ITEM_SIZE
			
		loop INNER_LOOP
		pop cx
		
		xchg dx, array[bx]			; dx = array[i], array[i] = array[minIndex]
		mov array[di], dx			; array[minIndex] = dx
				
		add bx, ITEM_SIZE
				
	loop SECOND_LOOP
				
	; вычисляем среднее второго и минимального элементов базового массива 
	; т.к. после сортировки в начале оказались отрицательные элементы в порядке возрастания, первый и будет минимальным
	add ax, [array]
	mov dx, 2
	idiv dl

	; получаем массив результата
	; АL = минимальное значение для помещения в результат
	; BX = базовый адрес i-го элемента базового массива
	; DI = базовый адрес j-го элемента массива результата
	; DX = промежуточное хранение данных
	mov cx, ITEM_COUNT
	lea bx, array
	lea di, result
	RESULT_LOOP:
	
		cmp [bx], al 			; array[i] > AL
		jle result_check
		
			mov dx, [bx]		; result[k] = array[i]
			mov [di], dx
			add di, ITEM_SIZE	; k++
		
		result_check:
		
		add bx, ITEM_SIZE
				
	loop RESULT_LOOP
	
	; конец программы
	xor bx, bx
	xor dx, dx
	xor di, di
	xor si, si
	
	mov ax, 4c00h	; функция выхода с кодом 0
	int	21h		

main endp
	
end	main