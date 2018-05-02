namespace BishopTakeshi.Messages.V1.Events
{
    public class ValueReceived
    {
        public string Value { get; set; }

        public ValueReceived(string value)
        {
            Value = value;
        }
    }
}
