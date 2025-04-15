using Business.Abstract;
using DataAccess.DTO;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _jobService.TGetAll();

            var jobDTOs = jobs.Select(j => new JobDTO
            {
                JobID = j.JobID,   // Job içinde JobID olduğundan emin ol
                JobName = j.JobName,
                UserID = j.UserID
            }).ToList();

            return Ok(jobDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = _jobService.TGetById(id);
            if (job == null)
            {
                return NotFound(new { Message = "Job not found." });
            }

            var jobDTO = new JobDTO
            {
                JobID = job.JobID,
                JobName = job.JobName,
                UserID = job.UserID
            };

            return Ok(jobDTO);
        }

        [HttpPost]
        public IActionResult Add([FromBody] JobDTO jobDto)
        {
            if (jobDto == null) return BadRequest("Invalid job data.");

            var job = new Job
            {
                JobID = jobDto.JobID,
                JobName = jobDto.JobName,
                UserID = jobDto.UserID
            };

            _jobService.TInsert(job);
            return Ok(new { Message = "Job added successfully." });
        }

        [HttpPut]
        public IActionResult Update([FromBody] JobDTO jobDto)
        {
            if (jobDto == null) return BadRequest("Invalid job data.");

            var job = new Job
            {
                JobID = jobDto.JobID,
                JobName = jobDto.JobName,
                UserID = jobDto.UserID
            };

            _jobService.TUpdate(job);
            return Ok(new { Message = "Job updated successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var job = _jobService.TGetById(id);
            if (job == null)
            {
                return NotFound(new { Message = "Job not found." });
            }

            _jobService.TDelete(job);
            return Ok(new { Message = "Job deleted successfully." });
        }
    }
}
