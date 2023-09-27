using System.Windows.Forms.DataVisualization.Charting;

namespace graphics;

public partial class Form1 : Form
{
    public Form1()
    {
        Chart chart1 = new Chart();
        chart1.Dock = DockStyle.Fill;

        ChartArea chartArea = new ChartArea();
        chart1.ChartAreas.Add(chartArea);

        // Daqui pra cima você teoricamente pode fazer por interface
        // Mas pode fazer por código também :)

        Series series = new Series();
        series.ChartType = SeriesChartType.Bar;
        // Para o gráfico de pizza use a mesma coisa
        // Não precisa se preocupar muito com o valor de x,
        // só usar 1, 2, 3 em diante e se importar com
        // o valor de y.
        
        series.Points.Add(new DataPoint(1, 10));
        series.Points.Add(new DataPoint(2, 20));
        series.Points.Add(new DataPoint(3, 30));
        series.Points.Add(new DataPoint(4, 40));
        series.Points.Add(new DataPoint(5, 50));
        chart1.Series.Add(series);

        // Daqui pra baixo você teoricamente pode fazer por interface
        // Mas pode fazer por código também :)

        this.Controls.Add(chart1);
    }
}
