using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piedone.Facebook.Suite.Models
{
    public interface IFacebookCommentsBox : ISocialPlugin
    {
        int NumberOfPosts { get; set; }
    }
}
