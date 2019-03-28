import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-body',
  templateUrl: './main-body.component.html',
  styleUrls: ['./main-body.component.css']
})

export class MainBodyComponent implements OnInit {
  canvas: any;
  context: CanvasRenderingContext2D;
  points: {x: number, y: number, r: number, hit: boolean}[] = [];

  readonly canvasSize: number = 705;
  readonly center: number = 353;
  readonly cellSize: number = 70.5;
  readonly dotRadius: number = 7;

  constructor() {
    let xhr = new XMLHttpRequest();
    xhr.open('GET', 'rest/point/getpoints', false);
    xhr.send();
    if (xhr.status == 200) {
      this.points = JSON.parse(xhr.responseText);
    }
    else alert("Ошибка " + xhr.status + ": " + xhr.statusText);
  }

  ngOnInit(): void {
    this.canvas = document.getElementById("canvas");
    this.context = this.canvas.getContext("2d");
    this.context.font = "22px Arial";
    this.context.textAlign = "center";

    if (this.points.length > 0) {
      document.forms["form"]["R"].value = this.points[0].r;
    }

    this.updateCanvas();
  }

  drawArea(r: number): void {
    const areaSize: number = this.cellSize * r ^ 0;

    this.context.clearRect(0, 0, this.canvasSize, this.canvasSize);
    this.context.fillStyle = "#FFCC00";

    //Квадрат R x R в II четверти
    this.context.fillRect(this.center - areaSize, this.center - areaSize, areaSize, areaSize);

    ///треугольник в IV четверти
    this.context.beginPath();
    this.context.moveTo(this.center + areaSize/2, this.center);
    this.context.lineTo(this.center, this.center);
    this.context.lineTo(this.center, this.center + areaSize/2);
    this.context.fill();

    //сектор радиуса R/2 в III четверти
    this.context.moveTo(this.center, this.center);
    this.context.arc(this.center, this.center, areaSize/2, Math.PI, Math.PI/2, true);
    this.context.fill();
    this.context.closePath();

    this.context.fillStyle = "#000000";
    this.drawAxis();
    this.drawCoordinates(r, areaSize);
    this.drawPoints();
  }

  drawAxis(): void {
    const oddSize: number = 11, evenSize: number = 19;
    const thickness: number = 5, spacing: number = 30;

    let x: number = 0, y: number = 0;
    let even: boolean = true;

    for (let i: number = 0; i <= 20; i++) {
      let size = even ? evenSize : oddSize;
      let offset = size / 2 ^ 0;
      even = !even;

      if (i == 10) {
        x++;
        y++;
      }
      else {
        this.context.fillRect(x, this.center - offset, thickness, size);
        this.context.fillRect(this.center - offset, y, size, thickness);
      }
      x += thickness + spacing;
      y += thickness + spacing;
    }

    this.context.fillRect(0, this.center - 2, this.canvasSize, thickness);
    this.context.fillRect(this.center - 2, 0, thickness, this.canvasSize);
  }

  drawCoordinates(r: number, areaSize: number): void {
    this.context.font.fontsize(20);
    const offset = r == 5 ? 10 : 0;

    this.context.fillText((r / 2).toString(), this.center - areaSize / 2 ^ 0, this.center + 20);
    this.context.fillText((r / 2).toString(), this.center + areaSize / 2 ^ 0, this.center - 20);
    this.context.fillText((r / 2).toString(), this.center + 20, this.center + areaSize / 2 ^ 0);

    this.context.fillText(r.toString(), this.center - areaSize + offset, this.center - 20);
    this.context.fillText(r.toString(), this.center + 20, this.center - areaSize + 2 * offset);
  }

  drawPoints(): void {
    for(let point of this.points) {
      this.context.fillStyle = (point.hit  ? "Green" : "Red");
      this.context.beginPath();
      this.context.arc(this.center + point.x * this.cellSize ^ 0, this.center - point.y * this.cellSize ^ 0,
        this.dotRadius, 0, 2 * Math.PI);
      this.context.fill();
      this.context.closePath();
    }
  }

  getMousePos(e: MouseEvent) {
    const rect: ClientRect = this.canvas.getBoundingClientRect();
    return {
      x: e.clientX - rect.left,
      y: e.clientY - rect.top
    }
  }

  check(x: number, y: number, r: number): boolean {
    function distance(a, b) {
      return Math.sqrt(Math.pow(a.x - b.x, 2) + Math.pow(a.y - b.y, 2));
    }

    function triangleArea(a, b, c) {
      let ab = distance(a, b), bc = distance(b, c), ca = distance(c, a), p = (ab + bc + ca) / 2;
      return Math.sqrt(p * (p - ab) * (p - bc) * (p - ca));
    }

    let center = {x: 0, y: 0};

    //Квадрат R x R в II четверти
    if (x >= -r && x <= 0 && y >= 0 && y <= r)
      return true;

    //сектор радиуса R/2 в III четверти
    let p = {x: x, y: y};
    if (x <= 0 && y <= 0 && distance(center, p) <= r / 2)
      return true;

    ///треугольник в IV четверти
    let a = {x: r / 2, y: 0}, b = {x: 0, y: -r / 2};
    let abc = triangleArea(a, b, center),
      abp = triangleArea(a, b, p),
      acp = triangleArea(a, p, center),
      bcp = triangleArea(p, b, center);

    return Math.abs(abp + acp + bcp - abc) < 1E-5;
  }

  updateCanvas(): void {
    let r: number = document.forms["form"]["R"].value;
    this.drawArea(r);
  }

  onCanvasClick(e: MouseEvent): void {
    let r: number = document.forms["form"]["R"].value;
    const coordinates = this.getMousePos(e);

    const visualCenter: number = Math.ceil(this.canvas.clientWidth / 2);
    const visualCellSize: number = this.canvas.clientWidth / 10;

    const x: number = (coordinates.x - visualCenter) / visualCellSize;
    const y: number = (visualCenter - coordinates.y) / visualCellSize;

    this.points.push( { x: x, y: y, r: r, hit: this.check(x, y, r) } );

    document.forms["click_form"]["X"].value = x;
    document.forms["click_form"]["Y"].value = y;
    document.forms["click_form"]["R"].value = r;

    document.forms["click_form"].submit();

    this.updateCanvas();
  }

  onFormSubmit() {
    function isNumeric(value: any): boolean {
      return !isNaN(value - parseFloat(value));
    }

    let y: number = document.forms["form"]["Y"].value;
    if (!isNumeric(y) || y > 3 || y < -5) return;

    let x: number = document.forms["form"]["X"].value;
    let r: number = document.forms["form"]["R"].value;
    this.points.push( { x: x, y: y, r: r, hit: this.check(x, y, r) } );

    this.updateCanvas();
  }

  onRadiusChange() {
    let r: number = document.forms["form"]["R"].value;

    this.points.forEach(p => {
      p.r = r;
      p.hit = this.check(p.x, p.y, r);
    });

    let xhr = new XMLHttpRequest();
    xhr.open('GET', 'rest/point/update?r=' + r, true);
    xhr.send();

    this.updateCanvas();
  }
}
