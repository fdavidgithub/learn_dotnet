window.onload = function() {

{% for title in context.titles %}        
    var ctx{{ forloop.counter }} = document.getElementById("{{ context.canva }}{{ forloop.counter }}").getContext('2d');
	window.myLine = new Chart(ctx{{ forloop.counter }}, config{{ forloop.counter }});
{% endfor %}

};

{% for title in context.titles %}
        var config{{ forloop.counter }} = {
			type: 'line',
			
            data: {
                labels: [
                    'Jan', 
                    'February', 
                    'March', 
                    'April', 
                    'May', 
                    'June', 
                    'July'
                ],
				datasets: [{
					backgroundColor: window.chartColors.red,
					borderColor: window.chartColors.red,
					data: [
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor(),
						randomScalingFactor()
					],
					fill: false,
				}, ]
			},
			
            options: {
				responsive: true,
                legend: false,
			    tooltips: {
					mode: 'index',
					intersect: false,
				},
				hover: {
					mode: 'nearest',
					intersect: true
				},
				scales: {
					xAxes: [{
						display: true,
						scaleLabel: {
							display: false,
						}
					}],
					yAxes: [{
						display: true,
						scaleLabel: {
							display: true,
							labelString: 'ºC'
						}
					}]
				}
			}
		};
{% endfor %}

