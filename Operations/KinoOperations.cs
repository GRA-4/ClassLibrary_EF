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
        public KinoDbnewContext _context;
        public KinoOperations()
        {
            _context = new KinoDbnewContext();
        }

        //User

        public User GetUserByName(KinoDbnewContext context, User entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    User foundEntity = context.Set<User>().FirstOrDefault((e) => e.UserName.ToLower() == entity.UserName.ToLower());
                    return foundEntity;

                }
            }
            catch (Exception ex) { return null; }
        }


        public async Task<User> CreateUserAsync(KinoDbnewContext context, User entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<User>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<User> UpdateUserAsync(KinoDbnewContext context, User entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.UserId = id;
                    context.Set<User>().Update(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteUserAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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

                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<User>> GetAllUsers(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<User> entities = await context.Set<User>().ToListAsync();

                    return (List<User>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<User>> GetAllUsersByName(KinoDbnewContext context, string name)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<User> entities = await context.Set<User>().Where(u => u.UserName.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<User>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<User> GetUserById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    User entity = await context.Set<User>().FirstOrDefaultAsync((e) => e.UserId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Title
        public async Task<Title> CreateTitleAsync(KinoDbnewContext context, Title entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<Title>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();

                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Title> UpdateTitleAsync(KinoDbnewContext context, Title entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.TitleId = id;
                    context.Set<Title>().Update(entity);
                    await context.SaveChangesAsync();
                    transaction.Commit();

                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteTitleAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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
                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Title>> GetAllTitles(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Title> entities = await context.Set<Title>().ToListAsync();
                    return (List<Title>)entities;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<List<Title>> GetAllTitlesByName(KinoDbnewContext context, string name)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Title> entities = await context.Set<Title>().Where(u => u.NameTitle.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Title>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Title> GetTitleById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Title entity = await context.Set<Title>().FirstOrDefaultAsync((e) => e.TitleId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Role
        public async Task<Role> CreateRoleAsync(KinoDbnewContext context, Role entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<Role>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Role> UpdateRoleAsync(KinoDbnewContext context, Role entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.RoleId = id;
                    context.Set<Role>().Update(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteRoleAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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

                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Role>> GetAllRoles(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Role> entities = await context.Set<Role>().ToListAsync();

                    return (List<Role>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<Role>> GetAllRolesByName(KinoDbnewContext context, string name)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Role> entities = await context.Set<Role>().Where(u => u.RoleName.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Role>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Role> GetRoleById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Role entity = await context.Set<Role>().FirstOrDefaultAsync((e) => e.RoleId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Post
        public async Task<Post> CreatePostAsync(KinoDbnewContext context, Post entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<Post>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Post> UpdatePostAsync(KinoDbnewContext context, Post entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.PostId = id;
                    context.Set<Post>().Update(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeletePostAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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

                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Post>> GetAllPosts(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Post> entities = await context.Set<Post>().ToListAsync();

                    return (List<Post>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<Post>> GetAllPostsByName(KinoDbnewContext context, string name)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Post> entities = await context.Set<Post>().Where(u => u.NamePost.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Post>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Post> GetPostById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Post entity = await context.Set<Post>().FirstOrDefaultAsync((e) => e.PostId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //List
        public async Task<List> CreateListAsync(KinoDbnewContext context, List entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<List>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<List> UpdateListAsync(KinoDbnewContext context, List entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.ListId = id;
                    context.Set<List>().Update(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteListAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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

                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<List>> GetAllLists(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<List> entities = await context.Set<List>().ToListAsync();

                    return (List<List>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<List>> GetAllListsByName(KinoDbnewContext context, string name)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<List> entities = await context.Set<List>().Where(u => u.NameList.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<List>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List> GetListById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List entity = await context.Set<List>().FirstOrDefaultAsync((e) => e.ListId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }


        //Genre
        public async Task<Genre> CreateGenreAsync(KinoDbnewContext context, Genre entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<Genre>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Genre> UpdateGenreAsync(KinoDbnewContext context, Genre entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.GenreId = id;
                    context.Set<Genre>().Update(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteGenreAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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

                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Genre>> GetAllGenres(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Genre> entities = await context.Set<Genre>().ToListAsync();

                    return (List<Genre>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<List<Genre>> GetAllGenresByName(KinoDbnewContext context, string name)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Genre> entities = await context.Set<Genre>().Where(u => u.GenreName.ToLower().Contains(name.ToLower())).ToListAsync();

                    return (List<Genre>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Genre> GetGenreById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Genre entity = await context.Set<Genre>().FirstOrDefaultAsync((e) => e.GenreId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }



        //Comment
        public async Task<Comment> CreateCommentAsync(KinoDbnewContext context, Comment entity)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var createdEntity = await context.Set<Comment>().AddAsync(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<Comment> UpdateCommentAsync(KinoDbnewContext context, Comment entity, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    entity.CommentId = id;
                    context.Set<Comment>().Update(entity);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                    //string serializedEntity = JsonConvert.SerializeObject(entity);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }
        public async Task<bool> DeleteCommentAsync(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
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

                        transaction.Commit();
                        //string serializedEntity = JsonConvert.SerializeObject(entity);
                        return true;
                    }
                }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<List<Comment>> GetAllComments(KinoDbnewContext context)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    IEnumerable<Comment> entities = await context.Set<Comment>().ToListAsync();

                    return (List<Comment>)entities;
                }
            }
            catch (Exception ex) { return null; }

        }
        public async Task<Comment> GetCommentById(KinoDbnewContext context, int id)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Comment entity = await context.Set<Comment>().FirstOrDefaultAsync((e) => e.CommentId == id);

                    return entity;
                }
            }
            catch (Exception ex) { return null; }
        }



    }
}
