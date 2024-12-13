export function createChart(canvasId, config) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) {
         console.error(`Canvas with ID '${canvasId}' not found.`);
       return null;
    }
    return new Chart(canvas, config);
}

export function updateChart(chart, data) {
   if (chart) {
       chart.data.labels = data.labels;
        chart.data.datasets.forEach((dataset, index) => {
           dataset.data = data.datasets[index].data
      });
      
       chart.update();
   }
}