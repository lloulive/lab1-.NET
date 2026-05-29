using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Core;
using Newtonsoft.Json;

namespace WinFormsUI
{
    public partial class Form1 : Form
    {
        private BindingList<Workout> workouts;

        public Form1()
        {
            InitializeComponent();

            workouts = new BindingList<Workout>();

            dataGridViewWorkouts.DataSource = workouts;

            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnSaveJson.Click += btnSaveJson_Click;
            btnLoadJson.Click += btnLoadJson_Click;
            btnSaveXml.Click += btnSaveXml_Click;
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            WorkoutEditForm form = new WorkoutEditForm();

            if (form.ShowDialog() == DialogResult.OK && form.Workout != null)
            {
                workouts.Add(form.Workout);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridViewWorkouts.CurrentRow == null)
            {
                MessageBox.Show("Оберіть тренування для видалення");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Видалити вибране тренування?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Workout? selected =
                    dataGridViewWorkouts.CurrentRow.DataBoundItem as Workout;

                if (selected != null)
                {
                    workouts.Remove(selected);
                }
            }
        }

        private void btnSaveJson_Click(object? sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonConvert.SerializeObject(
                    workouts.ToList(),
                    Formatting.Indented);

                File.WriteAllText(dialog.FileName, json);

                MessageBox.Show("Дані збережено у JSON");
            }
        }

        private void btnLoadJson_Click(object? sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "JSON files (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(dialog.FileName);

                    var loaded =
                        JsonConvert.DeserializeObject
                        <BindingList<Workout>>(json);

                    workouts = loaded ?? new BindingList<Workout>();

                    dataGridViewWorkouts.DataSource = workouts;

                    MessageBox.Show("Дані завантажено з JSON");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка читання JSON: " + ex.Message);
                }
            }
        }

        private void btnSaveXml_Click(object? sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "XML files (*.xml)|*.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                XDocument xml =
                    new XDocument(
                        new XElement("Workouts",

                            workouts.Select(w =>

                                new XElement("Workout",

                                    new XElement("WorkoutType", w.WorkoutType),
                                    new XElement("DurationMinutes", w.DurationMinutes),
                                    new XElement("CaloriesBurned", w.CaloriesBurned),
                                    new XElement("WorkoutDate", w.WorkoutDate)
                                )
                            )
                        )
                    );

                xml.Save(dialog.FileName);

                MessageBox.Show("Дані збережено у XML");
            }
        }
    }
}