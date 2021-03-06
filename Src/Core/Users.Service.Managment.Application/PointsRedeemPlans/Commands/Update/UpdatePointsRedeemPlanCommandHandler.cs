﻿using AutoMapper;
using BaseClasses.Core.Utilities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Application.PointsRedeemPlans.Commands.Update
{
    public class UpdatePointsRedeemPlanCommandHandler : IRequestHandler<UpdatePointsRedeemPlanCommand, int>
    {
        private readonly IUserDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePointsRedeemPlanCommandHandler(IUserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePointsRedeemPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PointsRedeemPlans.FindAsync(request.Id);
            entity = _mapper.Map(request, entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}