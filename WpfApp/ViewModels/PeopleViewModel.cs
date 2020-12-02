using Microsoft.Win32;
using Models;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public abstract class PeopleViewModel<TEntity, TService> where TEntity : Person where TService : ICrudService<TEntity>
    {
        protected abstract TService Service { get; }

        public ObservableCollection<TEntity> People { get; } = new ObservableCollection<TEntity>();
        public TEntity SelectedPerson { get; set; }
        public PeopleViewModel()
        {
            People.Clear();
            foreach (var person in Service.Read())
            {
                People.Add(person);
            }
        }

        public ICommand DeleteCommand => new CustomCommand(obj => { Service.Delete(SelectedPerson.Id); People.Remove(SelectedPerson); }, obj => SelectedPerson != null && People.Contains(SelectedPerson));
        public abstract ICommand AddCommand { get; }
        public ICommand EditCommand => new CustomCommand(obj => AddOrEdit(SelectedPerson), obj => SelectedPerson != null);

        public ICommand ExportCommand => new CustomCommand(x => Export(SelectedPerson), x => SelectedPerson != null);
        public ICommand ExportXmlCommand => new CustomCommand(x => ExportXml(SelectedPerson), x => SelectedPerson != null);

        private void ExportXml(TEntity selectedPerson)
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "XML|*.xml|ALL|*.*"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            string json = JsonConvert.SerializeObject(selectedPerson);
            var xml = JsonConvert.DeserializeXNode(json, selectedPerson.GetType().Name);
            xml.Save(dialog.FileName);
        }

        private void Export(TEntity selectedPerson)
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "JSON|*.json|ALL|*.*"
            };
            if(dialog.ShowDialog() != true)
            {
                return;
            }

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(selectedPerson, jsonSettings);

            File.WriteAllText(dialog.FileName, json);
            //using (var fileStream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
            //using (var streamWriter = new StreamWriter(fileStream))
            //{
            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //}

        }

        public ICommand ImportCommand => new CustomCommand(x => Import(), x => true);

        private void Import()
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "JSON|*.json|ALL|*.*"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            var person = JsonConvert.DeserializeObject<TEntity>(File.ReadAllText(dialog.FileName));
            person.Id = 0;
            AddOrEdit(person);
        }

        public void AddOrEdit(TEntity person)
        {
            var clone = (TEntity)person.Clone();

            var dialog = CreateAddEditDialog(clone);
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if(clone.Id == 0)
            {
                clone.Id = Service.Create(clone);
            }
            else
            {
                Service.Update(clone.Id, clone);
                People.Remove(person);
            }
            People.Add(clone);
        }


        protected abstract Window CreateAddEditDialog(TEntity clone);
    }
}
