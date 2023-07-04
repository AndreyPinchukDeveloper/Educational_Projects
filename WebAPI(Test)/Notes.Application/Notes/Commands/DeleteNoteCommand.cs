namespace Notes.Application.Notes.Commands
{
    public class DeleteNoteCommand:IReques
    {
        public Guid UserId {get;set;}
        public Guid Id {get;set;}

    }
}