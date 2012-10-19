function renderChart(id, reps, weight, max, load) {
    var chart;
    $(document).ready(function () {
        chart = new Highcharts.Chart({
            chart: {
                renderTo: 'chart-container-' + id,
                zoomType: 'xy'
            },
            title: {
                text: null
            },
            subtitle: {
                text: null
            }, credits: {
                enabled: false
            },
            legend: {
                enabled: false
            },
            xAxis: [{
                minTickInterval: 1,
                tickInterval: 1
            }],
            yAxis: [{ // Weight
                minTickInterval: 1,
                maxPadding: 0.1,
                labels: {
                    formatter: function () {
                        return this.value.toFixed(0) + ' kg';
                    },
                    style: {
                        color: '#89A54E'
                    }
                },
                title: {
                    text: '',
                    style: {
                        color: '#89A54E'
                    }
                },
                opposite: true

            }, {// Reps
                maxPadding: 0,
                minTickInterval: 1,
                title: {
                    text: '',
                    style: {
                        color: '#aaa'
                    }
                },
                labels: {
                    formatter: function () {
                        return this.value + ' reps';
                    },
                    style: {
                        color: '#aaa'
                    }
                }

            }, { // Max
                minTickInterval: 1,
                gridLineWidth: 1,
                gridLineColor: '#eee',
                title: {
                    text: '',
                    style: {
                        color: '#AA4643'
                    }
                },
                labels: {
                    formatter: function () {
                        return this.value.toFixed(0) + ' kg';
                    },
                    style: {
                        color: '#AA4643'
                    }
                },
                opposite: true
            }, { // Load
                minTickInterval: 1,
                gridLineWidth: 0,
                title: {
                    text: '',
                    style: {
                        color: '#6575DB'
                    }
                },
                labels: {
                    formatter: function () {
                        return this.value.toFixed(0) + ' kg';
                    },
                    style: {
                        color: '#6575DB'
                    }
                },
                opposite: true
            }], plotOptions: {
                areaspline: {
                    lineWidth: 2.5,
                    fillOpacity: .2,
                    marker: {
                        lineColor: '#fff',
                        lineWidth: 1,
                        radius: 3.5,
                        symbol: 'circle'
                    },
                    shadow: false
                },
                column: {
                    fillOpacity: .3,
                    lineWidth: 16,
                    shadow: false,
                    borderWidth: 0,
                    groupPadding: .3,
                },
                series: {
                    pointInterval: 1
                }
            },
            tooltip: {
                formatter: function () {
                    var unit = {
                        'Repetitions': 'reps',
                        'Weight': 'kg',
                        '1 Rep Max': 'kg',
                        'Load': 'kg'
                    }[this.series.name];

                    return '' + this.series.name + ': ' + this.y + ' ' + unit;
                }
            },
            series: [{
                index: 0,
                name: 'Repetitions',
                color: '#DEDEDE',
                type: 'column',
                yAxis: 1,
                data: reps,
                pointStart: 1

            }, {
                index: 2,
                name: '1 Rep Max',
                type: 'spline',
                color: '#AA4643',
                yAxis: 2,
                data: max,
                marker: {
                    enabled: false
                },
                dashStyle: 'shortdot',
                pointStart: 1

            }, {
                index: 3,
                yAxis: 2,
                name: 'Weight',
                color: '#89A54E',
                type: 'spline',
                data: weight,
                pointStart: 1
            }, {
                index: 1,
                name: 'Load',
                color: '#6575DB',
                type: 'areaspline',
                yAxis: 3,
                data: load,
                dashStyle: 'shortdot',
                pointStart: 1
            }]
        });
    });
}