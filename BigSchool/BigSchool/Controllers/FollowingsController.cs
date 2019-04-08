using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

   
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FollowerId == followingDto.FolloweeId))
                return BadRequest("Following already exists!");
            var following = new Following
            {
                FolloweeId = followingDto.FolloweeId,
                FollowerId = userId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
        // GET: Followings
       
    }
}