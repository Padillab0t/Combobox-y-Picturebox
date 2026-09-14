using System.Diagnostics;

namespace Combobox_y_Picturebox
{
    public partial class Form1 : Form
    {
        //Ruta donde se encuentra las imágenes
        private readonly string rutaRecursos = Path.Combine(Application.StartupPath, "Resources");

        public Form1()
        {
            InitializeComponent();
            //Cargar las distribuciones al iniciar
            cargarDistribuciones();

            //Configurar el PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //=======================================================
        //Cargar las distros en el COMBOBOX
        //=======================================================
        private void cargarDistribuciones()
        {
            comboBox1.Items.Clear();

            comboBox1.Items.Add("Puppy Linux");
            comboBox1.Items.Add("Slax");
            comboBox1.Items.Add("antix");
            comboBox1.Items.Add("Debian");
            comboBox1.Items.Add("Tiny Core Linux");

            //No seleccionar ningun item al inicio
            comboBox1.SelectedIndex = -1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Revisar el combobox tenga informacion
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            string distroSelecionada = comboBox1.SelectedItem.ToString();
            switch (distroSelecionada)
            {
                case "Puppy Linux":
                    MostrarDistro(
                        "Puppy Linux",
                        "Puppy Linux es una distribución ligera" +
                        "diseñada para funcionar correctamente en" +
                        "equipos de pocos recursos.\r\n\r\n" +
                        "Requisitos aproximados:\r\n" +
                        "· Procesador X86 o compatible\r\n" +
                        "· 1 Giga de RAM recomendado\r\n" +
                        "· Espacio reducido en disco",
                        "puppy.png",
                        "https://puppylinux-woof-ce.github.io/");
                    break;

                case "Slax":
                    MostrarDistro(
                        "Slax",
                        "Slax es una distribucion pequeña y" +
                        "portable que puede ejecutarse desde una" +
                        "nenirui USB.\r\n\r\n" +
                        "Requisitos aproximados:\r\n" +
                        "· Procesador X86_64 o compatible\r\n" +
                        "· 512 Megas de RAM o más\r\n" +
                        "· Espacio reducido en disco",
                        "slax.png",
                        "https://www.slax.org/");
                    break;

                case "antix":

                    MostrarDistro(
                        "antix",
                        "antiX es una distribución Linux ligera " +
                        "basada en Debian y orientada especialmente " +
                        "a equipos antiguos.\r\n\r\n" +
                        "Requisitos aproximados:\r\n" +
                        "• Procesador compatible con x86_64\r\n" +
                        "• 512 MB de RAM como mínimo recomendado\r\n" +
                        "• Poco espacio de almacenamiento",
                        "antix.png",
                        "https://antixlinux.com/");
                    break;

                case "Debian":

                    MostrarDistro(
                        "Debian",
                        "Debian es una de las distribuciones Linux " +
                        "más conocidas y utilizadas. Puede instalarse " +
                        "con diferentes entornos de escritorio y también " +
                        "puede configurarse para equipos con pocos recursos.\r\n\r\n" +
                        "Requisitos aproximados:\r\n" +
                        "• Procesador compatible\r\n" +
                        "• 512 MB de RAM para instalaciones ligeras\r\n" +
                        "• Espacio de almacenamiento variable",
                        "debian.png",
                        "https://www.debian.org/");
                    break;

                case "Tiny Core Linux":

                    MostrarDistro(
                        "Tiny Core Linux",
                        "Tiny Core Linux es una distribución " +
                        "extremadamente pequeña que está diseñada " +
                        "para utilizar muy pocos recursos del equipo.\r\n\r\n" +
                        "Requisitos aproximados:\r\n" +
                        "• Procesador compatible\r\n" +
                        "• 128 MB de RAM o más\r\n" +
                        "• Muy poco espacio de almacenamiento",
                        "tiny.jpg",
                        "http://www.tinycorelinux.net/");
                    break;
            }
        }
        //==================================
        //MÉTODO PARA MOSTRAR LA INFORMACIÓN
        //==================================
        private void MostrarDistro(
    string nombre,
    string descripción,
    string nombreImagen,
    string url)
        {
            //Mostrar la descripción
            label1.Text =
                nombre + "\r\n\r\n" + descripción;
            //Información de descarga
            linkLabel1.Tag = url;
            //Mostramos el enlace
            linkLabel1.Text = "Visitar sitio web de " + nombre;

            // =====================
            // Cargar la imagen 
            // =====================
            try
            {
                string rutaImagen =
                    Path.Combine(rutaRecursos, nombreImagen);
                if (File.Exists(rutaImagen))
                {
                    //libera imagen anterior
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    pictureBox1.Image = Image.FromFile(rutaImagen);
                }
                else
                {
                    pictureBox1.Image = null;

                    MessageBox.Show("No se encontró la imagen: " + rutaImagen);
                }
            }
            catch (Exception ex)
            {
                pictureBox1.Image = null;
                MessageBox.Show("Error al descargar la imagen: \r\n\r\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (linkLabel1.Tag != null)
                {
                    string url = linkLabel1.Tag.ToString();
                    Process.Start(
                        new ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true,
                        });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible abrir el enlace. \r\n\r\n" + ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
