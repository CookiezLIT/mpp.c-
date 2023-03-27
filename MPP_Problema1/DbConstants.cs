namespace MPP_Problema1
{
    public static class DbConstants
    {
        public const string Schema = "public";

        public static class Tables
        {
            public class Users
            {
                public const string Table = "public.user";

                public static class Columns
                {
                    public const string Id = "id";
                    public const string Name = "name";
                    public const string Password = "password";
                }
            }

            public class Flights
            {
                public const string Table = "public.flight";

                public static class Columns
                {
                    public const string Id = "id";
                    public const string Departure = "departure";
                    public const string Destination = "destination";
                    public const string DepartureDateTime = "departure_date_time";
                    public const string DestinationDateTime = "arrival_date_time";
                }
            }
        }
    }
}
