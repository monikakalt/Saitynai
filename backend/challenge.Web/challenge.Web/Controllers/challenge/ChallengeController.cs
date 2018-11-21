using challenge.Application.main.challenges;
using challenge.Application.main.challenges.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace challenge.Web.Controllers.challenge
{
    [Authorize]
    [Route("/[controller]")]
    public class ChallengeController : Controller
    {
        protected readonly IChallengeService _challengeService;
        public ChallengeController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetChallenges()
        {
            try
            {
                var challenges = _challengeService.GetAllChallenges();
                if(challenges != null)
                    return Ok(challenges);
                return NotFound();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Source);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetChallengesById(int id)
        {
            try
            {
                var challenge = _challengeService.GetChallengeById(id);
                if (challenge != null)
                    return new ObjectResult(challenge);
                return NotFound();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Source);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostChallenge([FromBody] ChallengeDto challenge)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                challenge.CreatedAt = DateTime.Today;
                _challengeService.PostChallenge(challenge);
                string newUri = Url.Link("GetChallenges", new { id = challenge.Id });
                return Created(newUri, challenge);

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return BadRequest();
        }
    }

}