namespace pjControlRegistroParticipantes
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cJefe, cOperario, cAdiministrativo, cPracticante;
        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Està seguro de salir?",
                                               "Control de Registro de Participantes",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

            private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblFecha.Text = DateTime.Now.ToString("d");
            lblNumero.Text = num.ToString("D4");
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando datos
            DateTime fecha, hora;
            string participante, cargo;
            int numero;
            participante = txtParticipante.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;

            //Contabilizar la cantidad según los cargos
            switch (cargo)
            {
                case "Jefe": cJefe++; break;
                case "Operario": cOperario++; break;
                case "Administrativo": cAdiministrativo++; break;
                case "Practicante": cPracticante++; break;
            }
            //Imprimir el registro
            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //Imprimir estadísticas
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem rom;

            //Añadiendo la primera fila lvEstadísticas
            elementosFila[0] = "Jefe";
            elementosFila[1] = cJefe.ToString();
            rom = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(rom);

            //Añadiendo la segunda fila lvEstadísticas
            elementosFila[0] = "Operario";
            elementosFila[1] = cOperario.ToString();
            rom = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(rom);

            //Añadiendo la tercera fila lvEstadísticas
            elementosFila[0] = "Administrativo";
            elementosFila[1] = cAdiministrativo.ToString();
            rom = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(rom);

            //Añadiendo la cuarta fila lvEstadísticas
            elementosFila[0] = "Practicante";
            elementosFila [1] = cPracticante.ToString();
            rom = new ListViewItem (elementosFila);
            lvEstadisticas .Items.Add(rom);

            //Mostando el nuevo número de registro
            num++;
            lblNumero.Text = num.ToString("D4");

            //Limpiando los controles
            txtParticipante.Clear();
            cboCargo.SelectedIndex = -1;
            txtParticipante.Focus();
        }
    }
}