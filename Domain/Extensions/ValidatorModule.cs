namespace Domain.Extensions
{
    public delegate bool Validator(string? data);

    public class ValidatorModule
    {
        public static bool IsValid(string? data, List<Validator> validators)
        {
            foreach (var validator in validators)
            {
                if (validator(data))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
