using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Structural
{
    public abstract class FileSystemComponent
    {
        protected string Name;
        public FileSystemComponent(string name) 
        {
            this.Name = name;
        }
        public abstract void Display(int depth);
    }
    public class File : FileSystemComponent
    {
        public File(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }
    }
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _children = new List<FileSystemComponent>();
        public Directory(string name) : base(name)
        {
        }

        public void Add(FileSystemComponent component)
        {
            _children.Add(component);
        }

        public void Remove(FileSystemComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);

            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }
    public class Composite
    {
        static void Main(string[] args)
        {
            Directory root = new Directory("Root");
            root.Add(new File("File1.txt"));
            root.Add(new File("File2.txt"));

            Directory subDir = new Directory("SubDirectory");
            subDir.Add(new File("File3.txt"));
            subDir.Add(new File("File4.txt"));

            root.Add(subDir);

            Directory nestedSubDir = new Directory("NestedSubDirectory");
            nestedSubDir.Add(new File("File5.txt"));
            subDir.Add(nestedSubDir);

            root.Display(1);
        }
         
    }
}
