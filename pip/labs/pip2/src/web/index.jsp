<%@ page import="java.util.ArrayList" %>
<style> <%@include file="/style.css" %> </style>
<script src="https://code.jquery.com/jquery-2.2.3.min.js"></script>
<!DOCTYPE html>
<html lang="en">
<meta charset="UTF-8">
<head>
    <title>Laboratory work #2</title>
</head>
<body>
    <header id="index_header">
        <h1>Laboratory work #2</h1>
        <h2>Variant 772</h2>
        <h3>Dmitry Sjestov</h3>
        <h3>Group P3217</h3>
        <h3>Teacher: V.V.Nikolaev</h3>
    </header>

    <img id="axis" style="visibility: hidden; width: 0; height: 0">

    <div class="outer" id="main_block">
        <div class="inner" id="canvas_block">
            <canvas id="canvas" width="705px" height="705px"> </canvas>
            <script>
                var canvas  = document.getElementById("canvas"),
                    context = canvas.getContext("2d");
                context.font = "24px Arial";
                context.textAlign = "center";

                const center = 353, cellSize = 70.5, dotRadius = 7;

                function drawArea(r) {
                    context.clearRect(0, 0, cellSize * 10, cellSize * 10);
                    const areaSize = cellSize * r ^ 0;
                    var radiusDefined = typeof(r) !== "undefined";
                    if (radiusDefined) {
                        context.fillStyle = "#FFCC00";
                        context.beginPath();
                        context.moveTo(center - areaSize, center);
                        context.lineTo(center, center);
                        context.arc(center, center, areaSize, 0, Math.PI * 1.5, true);
                        context.fill();
                        context.closePath();
                        context.fillRect(center, center, areaSize / 2 ^ 0, areaSize);
                    }
                    if (radiusDefined) drawCoordinates(r, areaSize);
                    drawAxis();
                    drawPoints(r);
                }

                function drawAxis() {
                    var axis = document.getElementById("axis");
                    context.drawImage(axis,0,0);
                }

                function drawCoordinates(r, areaSize) {
                    context.fillStyle = "Black";
                    var offset = r === 5 ? 10 : 0;
                    context.fillText(r, center - areaSize + offset, center - 20);
                    context.fillText(r, center + areaSize - offset, center - 20);
                    context.fillText(r, center + 20, center - areaSize + 2 * offset);
                    context.fillText(r, center - 20, center + areaSize);
                    context.fillText((r * 0.5).toString(), center + areaSize / 2 ^ 0, center + 30);
                }

                function drawPoints(r) {
                    $('table > tbody  > tr').each(function(index, element) {
                        var x = parseFloat(element.cells[1].innerHTML),
                            y = parseFloat(element.cells[2].innerHTML);
                        $.ajax({ method: "GET", url: "/check?r=" + r + "&x=" + x + "&y=" + y })
                            .always(function (data) {
                                var result = data === "Yes";
                                context.fillStyle = (result ? "Green" : "Red");
                                context.beginPath();
                                context.arc(center + x * cellSize ^ 0, center - y * cellSize ^ 0, dotRadius, 0, 2 * Math.PI);
                                context.fill();
                                context.closePath();
                            });
                    });
                }

                function updateCanvas() {
                    var input = document.forms["form"]["r_field"].value;
                    var r = parseInt(input);
                    var radiusDefined = input.length === 1 && r >= 1 && r <= 5;
                    drawArea(radiusDefined ? r : undefined);
                }

                function getMousePos(canvas, e) {
                    var rect = canvas.getBoundingClientRect();
                    return {
                        x: e.clientX - rect.left,
                        y: e.clientY - rect.top
                    };
                }

                canvas.addEventListener("click", canvasClickEvent, false);
                function canvasClickEvent(e) {
                    var input = document.forms["form"]["r_field"].value;
                    var r = parseInt(input);
                    if (input.length === 1 && r >= 1 && r <= 5)
                    {
                        var coordinates = getMousePos(canvas, e);
                        document.forms["form"]["x_field"].value = (coordinates.x - center) / cellSize;
                        document.forms["form"]["y_field"].value = (center - coordinates.y) / cellSize;
                        document.forms["form"].submit();
                    }
                    else alert("Unable to get coordinates")
                }
            </script>
        </div>

        <div class="inner" style="padding-left: 150px">
            <div id="validation_block">
                <form name="form" action="./check" onsubmit="return validate()" method="get">
                    <p id="info_field">Parameters:</p>
                    R: <input type="text" id="r_field" name="r" oninput="updateCanvas();"> <br><br>
                    X: <input type="text" id="x_field" name="x"> <br><br>
                    Y: <input type="text" id="y_field" name="y"> <br><br>
                    <input type="submit" value="Send">
                </form>
                <script>
                    function setInfoText(description) {
                        document.getElementById("info_field").innerHTML = description;
                        return false;
                    }

                    function validate() {
                        const int_regex = /^0|-?[1-9]\d*$/,
                            real_regex = /^0|-?(?:(?:[1-9]\d*(?:[,.]\d+)?)|0[,.]\d+)$/;

                        if (!int_regex.test(document.forms["form"]["r_field"].value))
                            return setInfoText("Incorrect input in radius field");

                        if (!real_regex.test(document.forms["form"]["x_field"].value))
                            return setInfoText("Incorrect input in X field");

                        if (!real_regex.test(document.forms["form"]["y_field"].value))
                            return setInfoText("Incorrect input in Y field");

                        var r = parseInt(document.forms["form"]["r_field"].value);
                        if (r < 1 || r > 5)  return setInfoText("Radius must be an integer between 1 and 5");

                        var x = parseFloat(document.forms["form"]["x_field"].value);
                        if (x < -5 || x > 5) return setInfoText("X must be between -5 and 5");

                        var y = parseFloat(document.forms["form"]["y_field"].value);
                        if (y < -5 || y > 5) return setInfoText("Y must be between -5 and 5");
                    }
                </script>
            </div>
        </div>
    </div>

    <div>
        <table id="table" border="1">
            <thead>
                <tr>
                    <th>Radius</th>
                    <th>X</th>
                    <th>Y</th>
                    <th>Included?</th>
                </tr>
            </thead>
            <tbody>
                <%
                    ServletContext context = session.getServletContext();
                    try {
                        ArrayList<Float> r = (ArrayList) context.getAttribute("r"),
                                x = (ArrayList) context.getAttribute("x"),
                                y = (ArrayList) context.getAttribute("y");
                        ArrayList<Boolean> result = (ArrayList) context.getAttribute("result");
                        int count = r.size();
                        for (int i = 0; i < count; i++) {
                            String resultStr = result.get(i) ? "Yes" : "No";
                            out.println("<tr>" +
                                        "   <td>" + r.get(i) + "</td>" +
                                        "   <td>" + x.get(i) + "</td>" +
                                        "   <td>" + y.get(i) + "</td>" +
                                        "   <td class=\"" + resultStr + "Row\">" + resultStr + "</td>" +
                                        "</tr>");
                        }
                    }
                    catch (Exception e) {}
                %>
            </tbody>
        </table>
    </div>

    <div style="text-align: center">
        <button onclick="clearHistory()" style="margin: auto">Clear history</button>
        <script>
            function clearHistory() {
                var table = document.getElementById("table");
                while(table.rows.length > 1) table.deleteRow(1);
                $.ajax({ method: "GET", url: "/clear" });
                updateCanvas();
            }

            var image = document.images[0];
            var downloadingImage = new Image();
            downloadingImage.onload = function(){
                image.src = this.src;
                drawArea();
            };
            downloadingImage.src = "/image";
        </script>
    </div>
</body>
</html>