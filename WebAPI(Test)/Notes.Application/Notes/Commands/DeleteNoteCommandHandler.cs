namespace Notes.Application.Notes.Commands
{
    public class DeleteNoteCommandHandler:IRequestHandler< DeleteNoteCommand >
    {
        private readonly INotesDbContext _context;
        public DeleteNoteCommandHandler(INotesDbContext context )
        {
            _context = context;
        }
        public async Task< Unit> Handle(DeleteNoteCommand request, CancellationToken CancellationToken)
        {
            var entity = await _context.Notes.FindAsync(hew object[] {request.Id }, cancellationToke);
            if(entity == null || entity.UserId != request.UserId )
            {
                throw new NotFoundException(nameof(Note ), request.Id );
            }
            return Unit.Value;//unit - empty answer 
        }
    }
}