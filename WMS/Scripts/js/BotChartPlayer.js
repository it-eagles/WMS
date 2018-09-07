// BotChartPlayer.js
var BOT_CHART_ENUM = {
    ExchangeRateDaily: 1,
    LoanRate: 2
};

function BotChartPlayer(opts) {
        opts = opts || {},
        opts.elementID = opts.elementID || 'chart',
        opts.width = opts.width || 1000,
        opts.height = opts.height || 450,
        opts.dateFormat = opts.dateFormat || '%Y-%m-%d',
        opts.x_column = opts.x_column || 'date',
        opts.y_column = opts.y_column || 'value',
        opts.uri = opts.uri || 'https://iapi.bot.or.th/Stat/Stat-ExchangeRate/DAILY_AVG_EXG_RATE_V1',
        opts.BOT_CHART_ENUM = opts.BOT_CHART_ENUM || BOT_CHART_ENUM.ExchangeRateDaily
    ;

    var dataSet = {};

    var svg = d3.select('#' + opts.elementID)
        .append("svg")
        .attr("width", opts.width)
        .attr("height", opts.height),
        margin = { top: 20, right: 20, bottom: 30, left: 50 },
        width = +svg.attr("width") - margin.left - margin.right,
        height = +svg.attr("height") - margin.top - margin.bottom,
        g = svg.append("g").attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    var parseTime = d3.timeParse(opts.dateFormat);

    var x = d3.scaleTime()
        .rangeRound([0, width]),
        y = d3.scaleLinear()
        .rangeRound([height, 0]);

    var line = d3.line()
        .x(function (d) { return x(parseTime(d[opts.x_column])); })
        .y(function (d) { return y(+d[opts.y_column]); });

    g.append("g")
        .attr("class", "axis-bottom grid");

    g.append("g")
        .attr("class", "axis-left grid")
        .append("text")
        .attr("fill", "#000")
        .attr("transform", "rotate(-90)")
        .attr("y", 6)
        .attr("dy", "0.71em")
        .attr("text-anchor", "end")
        .text("THB / USD");

    g.append("path")
        .attr("class", "line")
        .attr("fill", "none")
        .attr("stroke", "steelblue")
        .attr("stroke-linejoin", "round")
        .attr("stroke-linecap", "round")
        .attr("stroke-width", 1.5);

    var display = function (data) {
        x.domain(d3.extent(data, function (d) {
            return parseTime(d[opts.x_column]);
        }));
        y.domain(d3.extent(data, function (d) {
            return +d[opts.y_column];
        }));

        g.select(".axis-bottom")
            .attr("transform", "translate(0," + height + ")")
            .transition()
            .call(d3.axisBottom(x).ticks(10).tickSize(-height))
            .select(".domain")
            .remove();

        g.select(".axis-left")
            .transition()
            .call(d3.axisLeft(y).ticks(10).tickSize(-width));

        g.select(".line")
            .datum(data)
            .transition()
            .attr("d", line);
    }

    return {
        play: function (year, month) {
            var d = new Date(year, month, 0);

            var period = year + '-' + parseInt(month).pad(2),
                criteria = "start_period=" + period + "-01&end_period=" + period + "-" + d.getDate() + "&currency=USD";

            if (dataSet[period] == undefined) {
                d3.json(opts.uri + "/?" + criteria)
                    .header('api-key', 'U9G1L457H6DCugT7VmBaEacbHV9RX0PySO05cYaGsm')
                    .get(function (error, root) {
                        if (!error) {
                            var result = root.result;
                            if (result.success) {
                                var data = result.data.data_detail;
                                dataSet[period] = data;
                                display(dataSet[period]);
                            }
                        }
                    });
            } else {
                display(dataSet[period]);
            }
        }
    };
}