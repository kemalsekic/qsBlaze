namespace QStackAuth
{
    public class WeatherForecast
    {

        public WeatherForecast(DateOnly dateTime, int v1, string v3)
        {
            this.Date = dateTime;
            this.TemperatureC = v1;
            this.Summary = v3;
        }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
