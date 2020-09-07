using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Connamder.Controller
{

    //Route to call end point commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        //GET api/command
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDtos>> GetAllCommands()
        {
            var commandsItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDtos>>(commandsItems));
        }
        //GET api/commands/5
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDtos>(commandItem));
            }
            return NotFound();   
        }
        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDtos> CreateCommand(CommandCreatDto commandCreatDto)
        {
            var commandModel=_mapper.Map<Command>(commandCreatDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChange();
            //mapping back to client as our contract with client
            var commandReadDtos=_mapper.Map<CommandReadDtos>(commandModel);
            // Returning back the address of resourse as of REST artitecture
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDtos.Id}, commandReadDtos);
           
        }
        //PUT api /command/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
           
            
            _mapper.Map(commandUpdateDto, commandModelFromRepo); 


            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChange();

            return NoContent();
        }
        //PATCH api/command/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(commandToPatch, commandModelFromRepo); 

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChange();

            return NoContent();
        }
        //DELETE api/command/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChange();
            return NoContent();
        }


    }

}