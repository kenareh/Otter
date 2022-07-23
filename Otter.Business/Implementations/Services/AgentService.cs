using System;
using System.Collections.Generic;
using System.Linq;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Entities;
using Otter.Common.Exceptions;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class AgentService : IAgentService

    {
        private IUnitOfWork _unitOfWork;
        private IAgentFactory _agentFactory;

        public AgentService(IUnitOfWork unitOfWork, IAgentFactory agentFactory)
        {
            _unitOfWork = unitOfWork;
            _agentFactory = agentFactory;
        }

        public Agent Get(string agentCode)
        {
            var agent = _unitOfWork.AgentRepository.Find(p => p.Code == agentCode).FirstOrDefault();
            if (agent == null)
            {
                throw new EntityNotFoundException("نماینده یافت نشد.");
            }
            if (!agent.IsActive)
            {
                throw new EntityNotFoundException("نماینده غیر فعال می باشد.");
            }
            return agent;
        }

        public AgentDto Get(long id)
        {
            var agent = _unitOfWork.AgentRepository.Find(p => p.Id == id).FirstOrDefault();
            if (agent == null)
            {
                throw new EntityNotFoundException("نماینده یافت نشد.");
            }
            if (!agent.IsActive)
            {
                throw new EntityNotFoundException("نماینده غیر فعال می باشد.");
            }
            return _agentFactory.CreateDto(agent);
        }

        public List<AgentDto> Get()
        {
            var agents = _unitOfWork.AgentRepository.Find().ToList();
            return _agentFactory.CreateDto(agents).ToList();
        }

        public AgentDto Add(AgentDto dto)
        {
            var entity = _agentFactory.CreateEntity(dto);
            _unitOfWork.AgentRepository.Add(entity);
            _unitOfWork.Commit();
            return dto;
        }

        public AgentDto Edit(AgentDto dto)
        {
            var agent = _unitOfWork.AgentRepository.Find(p => p.Id == dto.Id).FirstOrDefault();
            if (agent == null)
            {
                throw new EntityNotFoundException("نماینده یافت نشد.");
            }
            if (!agent.IsActive)
            {
                throw new EntityNotFoundException("نماینده غیر فعال می باشد.");
            }
            agent.Code = dto.Code;
            agent.Name = dto.Name;
            agent.IsActive = dto.IsActive;
            _unitOfWork.Commit();
            return _agentFactory.CreateDto(agent);
        }

        public void Delete(long id)
        {
            var agent = _unitOfWork.AgentRepository.Find(p => p.Id == id).FirstOrDefault();
            if (agent == null)
            {
                throw new EntityNotFoundException("نماینده یافت نشد.");
            }
            if (!agent.IsActive)
            {
                throw new EntityNotFoundException("نماینده غیر فعال می باشد.");
            }

            agent.IsActive = false;
            _unitOfWork.Commit();
        }
    }
}