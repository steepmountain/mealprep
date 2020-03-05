namespace MealprepFull.Data.Entities.Recipes
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string MeasurementUnit { get; set; }
        public double CaloriesPerMeasurementUnit { get; set; }
    }
}