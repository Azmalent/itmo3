<!DOCTYPE html>
<?php
$time_start = microtime(true);

session_start();

$x = (float)$_POST['x'];
$y = (float)$_POST['y'];
$radius = (float)$_POST['r'];

class point
{
    public $x;
    public $y;

    function __construct($X, $Y)
    {
        $this->x = $X;
        $this->y = $Y;
    }
}

function distance($p1, $p2)
{
    $dx = $p1->x - $p2->x;
    $dy = $p1->y - $p2->y;
    return sqrt($dx * $dx + $dy * $dy);
}

function triangle_area($a, $b, $c)
{
    $ab = distance($a, $b);
    $bc = distance($b, $c);
    $ca = distance($c, $a);
    $p = ($ab + $bc + $ca) / 2;
    return sqrt($p * ($p - $ab) * ($p - $bc) * ($p - $ca));
}

function check($r, $point)
{
    $c = new point(0, 0);
    //четверть окружности
    if ($point->x <= 0 and $point-> y <= 0 and distance($c, $point) <= $r / 2) return true;

    //прямоугольник
    if ($point->x >= 0 and $point->x <= $r and $point->y >= $r/-2 and $point->y <= 0) return true;

    //треугольник
    $a = new point(-$r, 0);
    $b = new point(0, $r);
    $abc = triangle_area($a, $b, $c);
    $abp = triangle_area($a, $b, $point);
    $bcp = triangle_area($b, $c, $point);
    $cap = triangle_area($c, $a, $point);
    if(abs($abp + $bcp + $cap - $abc) < 1E-5) return true;

    return false;
}

$point = new point($x, $y);
$result = check($radius, $point);

if(!isset($_SESSION['r'])) $_SESSION['r'] = array($radius);
else $_SESSION['r'][] = $radius;

if(!isset($_SESSION['x'])) $_SESSION['x'] = array($x);
else $_SESSION['x'][] = $x;

if(!isset($_SESSION['y'])) $_SESSION['y'] = array($y);
else $_SESSION['y'][] = $y;

if(!isset($_SESSION['result'])) $_SESSION['result'] = array($result);
else $_SESSION['result'][] = $result;

?>

<html>
<header>
    <h1>Результаты</h1>
</header>
<head>
    <meta charset="UTF-8">
    <title>Результат</title>
    <link href="./css/styles.css" rel="stylesheet">
</head>
<body>
    <div class="text">
        <table border="1" style="border: dashed">
            <tr>
                <th>Радиус</th>
                <th>X</th>
                <th>Y</th>
                <th>Попадание</th>
            </tr>
            <?php
                $count = sizeof($_SESSION['result']);
                for ($i = 0; $i < $count; $i++)
                {
                    echo '<tr>';
                    echo '<td>', $_SESSION['r'][$i], '</td>';
                    echo '<td>', $_SESSION['x'][$i], '</td>';
                    echo '<td>', $_SESSION['y'][$i], '</td>';
                    $res = $_SESSION['result'][$i];
                    echo '<td><h4 value=', $res, '>', $res ? 'Да' : 'Нет', '</h4></td>';
                    echo '</tr>';
                }
            ?>
        </table>
    </div>

    <?php
    $timestamp = $_POST['timestamp'];

    $time_end = microtime(true);
    $work_time = round($time_end - $time_start, 5, PHP_ROUND_HALF_UP);
    ?>

    <div class="text" style="text-align: center">
        <p align="center"><b>Текущее время:</b> <?php echo $timestamp; ?> </p>
        <p align="center"><b>Время работы скрипта:</b> <?php echo $work_time; ?> мс</p>
    <button onclick="location.href='./index.html';">Назад</button>
    </div>


</body>
</html>