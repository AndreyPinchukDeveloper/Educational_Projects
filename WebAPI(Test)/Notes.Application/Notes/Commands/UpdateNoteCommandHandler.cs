using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateNoteCommandHandler(INotesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {

            }

            return Unit.Value;
        }
    }
    
}
