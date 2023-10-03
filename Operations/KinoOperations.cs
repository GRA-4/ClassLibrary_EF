using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_EF.Operations
{
    public class KinoOperations
    {
        private KinoDbnewContext _context;
        public KinoOperations()
        {
            _context = new KinoDbnewContext();
        }

        //User

        public User GetUserByName(User entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    User foundEntity = context.Set<User>().FirstOrDefault((e) => e.UserName.ToLower() == entity.UserName.ToLower());
                    return foundEntity;

                }
            }
            catch (Exception ex) { return null; }
        }


        public async Task<User> CreateUserAsync(User entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<User>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<User> UpdateUserAsync(User entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.UserId = id;
                    context.Set<User>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    User entity = await context.Set<User>().FirstOrDefaultAsync((e) => e.UserId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<User>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<User> entities = await context.Set<User>().ToListAsync();

                    return (List<User>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<User>> GetAllUsersByName(string name)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<User> entities = await context.Set<User>().Where(u => u.UserName.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<User>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<User> GetUserById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    User entity = await context.Set<User>().FirstOrDefaultAsync((e) => e.UserId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Title
        public async Task<Title> CreateTitleAsync(Title entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<Title>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Title> UpdateTitleAsync(Title entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.TitleId = id;
                    context.Set<Title>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteTitleAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Title entity = await context.Set<Title>().FirstOrDefaultAsync((e) => e.TitleId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<Title>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Title>> GetAllTitles()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Title> entities = await context.Set<Title>().ToListAsync();
                    return (List<Title>)entities;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<List<Title>> GetAllTitlesByName(string name)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Title> entities = await context.Set<Title>().Where(u => u.NameTitle.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Title>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Title> GetTitleById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Title entity = await context.Set<Title>().FirstOrDefaultAsync((e) => e.TitleId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Role
        public async Task<Role> CreateRoleAsync(Role entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<Role>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Role> UpdateRoleAsync(Role entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.RoleId = id;
                    context.Set<Role>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteRoleAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Role entity = await context.Set<Role>().FirstOrDefaultAsync((e) => e.RoleId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<Role>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Role> entities = await context.Set<Role>().ToListAsync();

                    return (List<Role>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<Role>> GetAllRolesByName(string name)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Role> entities = await context.Set<Role>().Where(u => u.RoleName.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Role>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Role> GetRoleById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Role entity = await context.Set<Role>().FirstOrDefaultAsync((e) => e.RoleId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Post
        public async Task<Post> CreatePostAsync(Post entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<Post>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Post> UpdatePostAsync(Post entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.PostId = id;
                    context.Set<Post>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Post entity = await context.Set<Post>().FirstOrDefaultAsync((e) => e.PostId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<Post>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Post> entities = await context.Set<Post>().ToListAsync();

                    return (List<Post>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<Post>> GetAllPostsByName(string name)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Post> entities = await context.Set<Post>().Where(u => u.NamePost.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Post>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Post> GetPostById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Post entity = await context.Set<Post>().FirstOrDefaultAsync((e) => e.PostId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //List
        public async Task<List> CreateListAsync(List entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<List>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<List> UpdateListAsync(List entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.ListId = id;
                    context.Set<List>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteListAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    List entity = await context.Set<List>().FirstOrDefaultAsync((e) => e.ListId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<List>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<List>> GetAllLists()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<List> entities = await context.Set<List>().ToListAsync();

                    return (List<List>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<List>> GetAllListsByName(string name)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<List> entities = await context.Set<List>().Where(u => u.NameList.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<List>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List> GetListById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    List entity = await context.Set<List>().FirstOrDefaultAsync((e) => e.ListId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Genre
        public async Task<Genre> CreateGenreAsync(Genre entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<Genre>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Genre> UpdateGenreAsync(Genre entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.GenreId = id;
                    context.Set<Genre>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteGenreAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Genre entity = await context.Set<Genre>().FirstOrDefaultAsync((e) => e.GenreId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<Genre>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Genre> entities = await context.Set<Genre>().ToListAsync();

                    return (List<Genre>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<Genre>> GetAllGenresByName(string name)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Genre> entities = await context.Set<Genre>().Where(u => u.GenreName.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Genre>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Genre> GetGenreById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Genre entity = await context.Set<Genre>().FirstOrDefaultAsync((e) => e.GenreId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }



        //Comment
        public async Task<Comment> CreateCommentAsync(Comment entity)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    var createdEntity = await context.Set<Comment>().AddAsync(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Comment> UpdateCommentAsync(Comment entity, int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    entity.CommentId = id;
                    context.Set<Comment>().Update(entity);
                    await context.SaveChangesAsync();


                    string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteCommentAsync(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Comment entity = await context.Set<Comment>().FirstOrDefaultAsync((e) => e.CommentId == id);
                    if (entity == null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Set<Comment>().Remove(entity);
                        await context.SaveChangesAsync();
                        string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Comment>> GetAllComments()
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    IEnumerable<Comment> entities = await context.Set<Comment>().ToListAsync();

                    return (List<Comment>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Comment> GetCommentById(int id)
        {
            try
            {
                using (KinoDbnewContext context = _context)
                {
                    Comment entity = await context.Set<Comment>().FirstOrDefaultAsync((e) => e.CommentId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }



    }
}
