
$(document).ready(function () {

    function viewModel() {
        var self = this;
        this.orderSummaryContent = ko.ob

        var dataForChart = $.parseJSON(jsModel);

        if (window.location.href.indexOf("Month") > -1) {
            $("#month").addClass("active");
        }
        else if (window.location.href.indexOf("Year") > -1) {
            $("#year").addClass("active");
        }
        else {
            $("#week").addClass("active");
        }

        drawChart(dataForChart);

        function drawChart(mydata) {
            Morris.Bar({
                element: 'line-chart',
                data: mydata,
                hoverCallback: function (index, options, content) {
                    return (content);
                },
                xkey: 'PeriodLabel',
                ykeys: ['TotalOrderedAmount', 'TotalShippedAmount'],
                stacked: false,
                labels: ['Series A', 'Series B'], // rename it for the 'onhover' caption change
                xLabelAngle: 60
            });

        };


        //        self.getDataByMonth = function () {
        //            var uri = 'http://ahcwebapi.azurewebsites.net/api/ordersummary/monthovermonth';
        //            $.ajax({
        //                url: uri,
        //                type: 'GET',
        //                datatype: 'json',
        //                success: function (data) {
        //                    $.each(data, function (key, order) {
        //                        var item = {
        //                            "Id": order.Id,
        //                            "PeriodDate": order.PeriodDate,
        //                            "PeriodLabel": order.PeriodLabel,
        //                            "Ordered": order.Ordered,
        //                            "Shipped": order.Shipped,
        //                            "TotalOrderedAmount": order.TotalOrderedAmount,
        //                            "TotalShippedAmount": order.TotalShippedAmount
        //                        };

        //                        viewmodel = ko.viewmodel.fromModel(item);
        //                        self.items.push(viewmodel);
        //                    });
        //                }
        //            });

        //        }


    };

    ko.applyBindings(new viewModel());

});

/*********************************/
//var dataForChart = $.parseJSON(jsModel);
//drawChart(dataForChart);
//    
//function drawChart(mydata) {
//    Morris.Bar({
//        element: 'line-chart',
//        data: mydata,
//        hoverCallback: function (index, options, content) {
//            return (content);
//        },
//        xkey: 'PeriodLabel',
//        ykeys: ['TotalOrderedAmount', 'TotalShippedAmount'],
//        stacked: false,
//        labels: ['Series A', 'Series B'], // rename it for the 'onhover' caption change
//        xLabelAngle: 60
////            xLabelFormat: function (periodDate) {
////                var monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec' ]
////                var date = new Date(periodDate);
////                return date.getDate() + ' ' + monthNames[date.getMonth() + 1] + ' ' + date.getFullYear();
////            }
//    });

//};