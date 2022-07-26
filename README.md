
[Remote(action:"IsEmailInUse",controller:"Home")]

====================

```
[AcceptVerbs("Get", "Post")]
    [AllowAnonymous]
    public async Task<IActionResult> IsEmailInUse(string email)
    {
        var user =await _dbContext.users.Where(x => x.Email == email).FirstOrDefaultAsync();
        if (user == null)
        {
            return Json(true);
        }
        else
        {
            return Json($"Email {email} is already in use");
        }
    }
