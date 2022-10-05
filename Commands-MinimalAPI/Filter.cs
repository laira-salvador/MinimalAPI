namespace Commands_MinimalAPI
{
    public class Filter
    {
        public string Property { get; set; }
        public string Value { get; set; }


        public static bool TryParse(string? value, out Filter? filter)
        {
            var trimmedValue = value?.Trim();
            var segments = trimmedValue?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (segments?.Length == 2)
            {
                filter = new Filter { Property = segments[0], Value = segments[1] };
                return true;
            }

            filter = null;

            return false;
        }
    }
}
