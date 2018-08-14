namespace BishopTakeshi.Service.Commands
{
    public class CreatePoll : IPollCommand
    {
        public string Name { get;  }

        public CreatePoll(string name)
        {
            Name = name;
        }
    }
}