using Application.Common.Attributes;
using Audit.Core;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class AuditLogsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<AuditLogsBehavior<TRequest, TResponse>> _logger;
        private readonly IConfiguration _config;

        public AuditLogsBehavior(ILogger<AuditLogsBehavior<TRequest, TResponse>> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request {@Request}", request);

            IAuditScope? scope = null;
            var auditLogAttributes = request.GetType().GetCustomAttributes(typeof(AuditLogAttribute), false);

            if (auditLogAttributes.Any())
            {
                scope = AuditScope.Create(_ => _
                .EventType(typeof(TRequest).Name)
                .ExtraFields(new
                {
                    Request = request
                }));
            }

            var result = await next();

            if (scope is not null)
            {
                await scope.DisposeAsync();
            }

            return result;
        }
    }
}
