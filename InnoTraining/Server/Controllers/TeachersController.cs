namespace InnoTraining.Server;

[Route("api/[controller]")]
[ApiController]

public class TeachersController:ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TeachersController(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

    [HttpGet]
    public List<Teacher> Get() => _applicationDbContext.Teachers.ToList();
    
    [HttpGet("{id}")]
    public Teacher Get(Guid id) => _applicationDbContext.Teachers.FirstOrDefault(e => e.Id == id) ?? new();

    [HttpPost]
    public void Post(Teacher teacher)
    {
        if (teacher == null) throw new ArgumentNullException();

        teacher.Id = Guid.NewGuid();
        teacher.BirthDate= DateTime.Now;

        _applicationDbContext.Teachers.Add(teacher);
        _applicationDbContext.SaveChanges();
    }

    [HttpPut]
    public Teacher Put(Teacher teacher)
    {
        Teacher? teacherFromDb = _applicationDbContext.Teachers.FirstOrDefault(e=>e.Id == teacher.Id);
        if (teacherFromDb is null) throw new ArgumentNullException();
        
        _applicationDbContext.Teachers.Update(teacher);
        _applicationDbContext.SaveChanges();

        return teacher;
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        Console.WriteLine(id.ToString());
        Teacher? teacherFromDb = _applicationDbContext.Teachers.FirstOrDefault(e => e.Id == id);
        if (teacherFromDb is null) throw new ArgumentNullException();

        _applicationDbContext.Teachers.Remove(teacherFromDb);
        _applicationDbContext.SaveChanges();
    }
}