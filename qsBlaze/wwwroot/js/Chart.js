function GeneratePieChart(userInfo) {
    var root = am5.Root.new("chartdiv");

    root.setThemes([
        am5themes_Animated.new(root)
    ]);

    var chart = root.container.children.push(am5percent.PieChart.new(root, { layout: root.verticalLayout }));

    var averageColors = userInfo.length;
    var redColors = 0;
    var greenColors = 0;
    var yellowColors = 0;

    for (i in userInfo) {
        if (userInfo[i].color == 'Red') {
            redColors++;
        } else if (userInfo[i].color == 'Green') {
            greenColors++;
        } else if (userInfo[i].color == 'Yellow') {
            yellowColors++;
        }
    }

    var dataSet = [
        { color: "Green", count: greenColors },
        { color: "Red", count: redColors },
        { color: "Yellow", count: yellowColors }
    ];


    console.log(redColors);
    console.log(greenColors);
    console.log(yellowColors);

    var series = chart.series.push(am5percent.PieSeries.new(root, {
        valueField: "count",
        categoryField: "color"
    }));

    series.data.setAll(dataSet);
    series.appear(1000, 100);

}

function GenerateXYChart(userInfo) {
    var root = am5.Root.new("chartdiv");

    root.setThemes([
        am5themes_Animated.new(root)
    ]);
    console.log(userInfo);

    var chart = root.container.children.push(
        am5xy.XYChart.new(root, {
            panY: false,
            wheelY: "zoomX",
            layout: root.verticalLayout
        })
    );

    // Define data
    var data = [{
        category: "Research",
        value1: 1000,
        value2: 588
    }, {
        category: "Marketing",
        value1: 1200,
        value2: 1800
    }, {
        category: "Sales",
        value1: 850,
        value2: 1230
    }];

    // Craete Y-axis
    let yAxis = chart.yAxes.push(
        am5xy.ValueAxis.new(root, {
            renderer: am5xy.AxisRendererY.new(root, {
            })
        })
    );

    // Create X-Axis
    var xAxis = chart.xAxes.push(
        am5xy.CategoryAxis.new(root, {
            maxDeviation: 0.2,
            renderer: am5xy.AxisRendererX.new(root, {
            }),
            categoryField: "firstName"
        })
    );
    xAxis.data.setAll(userInfo);

    // Create series
    var series1 = chart.series.push(
        am5xy.ColumnSeries.new(root, {
            name: "Series",
            xAxis: xAxis,
            yAxis: yAxis,
            valueYField: "assignedPoints",
            categoryXField: "firstName",
            tooltip: am5.Tooltip.new(root, {
                labelText: "were"
            })
        })
    );

    series1.data.setAll(userInfo);

    var series2 = chart.series.push(
        am5xy.ColumnSeries.new(root, {
            name: "Series",
            xAxis: xAxis,
            yAxis: yAxis,
            valueYField: "carryOverPoints",
            categoryXField: "firstName"
        })
    );
    series2.data.setAll(userInfo);

    // Add legend
    var legend = chart.children.push(am5.Legend.new(root, {}));
    legend.data.setAll(chart.series.values);

    //series.data.setAll(userInfo);
    //series.appear(1000, 100);

}
