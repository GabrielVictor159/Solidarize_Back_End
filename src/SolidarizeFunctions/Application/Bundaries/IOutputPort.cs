using Microsoft.AspNetCore.Mvc;

namespace Solidarize.Application.Bundaries;

public interface IOutputPort<T>
{
    IActionResult ViewModel { get; set; }

    void Standard(T output);
    void Error(string message);
    void NotFound(string message);
}
