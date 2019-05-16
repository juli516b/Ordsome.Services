using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Ordsome.Services.CrossCuttingConcerns.Languages;
using RequestService.Application.Exceptions;
using RequestService.Application.Interfaces;
using RequestService.Domain.Requests;

namespace RequestService.Application.Commands.Requests.RequestCreation
{
    public class CreateRequestCommand : IRequest
    {
        public int LanguageOriginId { get; set; }
        public int LanguageTargetId { get; set; }
        public string TextToTranslate { get; set; }
        public Guid UserId { get; set; }
    }

    public class Handler : IRequestHandler<CreateRequestCommand, Unit>
    {
        private readonly IRequestServiceDbContext _context;
        private readonly IMediator _mediator;

        public Handler(IRequestServiceDbContext context, INotificationService notificationService, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            ListOfLanguages listOfLanguages = new ListOfLanguages();

            var languageOrigin = listOfLanguages.GetLanguage(request.LanguageOriginId);

            var languageTarget = listOfLanguages.GetLanguage(request.LanguageTargetId);

            if (languageTarget == null)
            {
                throw new NotFoundException($"{request.LanguageTargetId}", languageOrigin);
            }

            if (languageOrigin == null)
            {
                string emptyLanguage = "Not set";
                var entity = new Request
                {
                    LanguageTarget = languageTarget.LanguageName,
                    LanguageOrigin = emptyLanguage,
                    TextToTranslate = request.TextToTranslate,
                    UserId = request.UserId
                };
                _context.Requests.Add(entity);
            }
            else
            {
                var entity = new Request
                {
                    LanguageTarget = languageTarget.LanguageName,
                    LanguageOrigin = languageOrigin.LanguageName,
                    TextToTranslate = request.TextToTranslate,
                    UserId = request.UserId
                };

                _context.Requests.Add(entity);
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}