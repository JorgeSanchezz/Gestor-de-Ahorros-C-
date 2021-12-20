Public Class Gestion
    Private Sub activarcontroles()
        txtCliente.Enabled = False
        btnAbrir.Enabled = False
        btnRetiros.Enabled = True
        btnDeposito.Enabled = True
    End Sub
    Private Sub desactivarControles()
        txtCliente.Enabled = True
        btnAbrir.Enabled = True
        btnRetiros.Enabled = False
        btnDeposito.Enabled = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        desactivarControles()
    End Sub
    Private monto As Double
    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        Dim cliente As String
        cliente = txtCliente.Text
        If (monto >= 0) Then
            activarcontroles()
        Else
            MessageBox.Show("El monto no puede ser inferior a cero",
                            "Gestion de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function leer(mensaje As String) As Double
        Dim cantidad As Double
        cantidad = InputBox("Ingrese el monto a" + mensaje, "Gestion de Ahorros", "0", 100, 0)
        Return cantidad
    End Function

    Private Sub Mostrar()
        txtSaldo.Text = monto
    End Sub

    Private Sub btnDeposito_Click(sender As Object, e As EventArgs) Handles btnDeposito.Click
        Dim deposito As Double
        deposito = leer("Depositar")
        monto = monto + deposito


        lstDeposito.Items.Add(deposito)
        Mostrar()
    End Sub

    Private Sub btnRetiros_Click(sender As Object, e As EventArgs) Handles btnRetiros.Click
        Dim retiro As Double
        retiro = leer("Retirar")

        If (retiro <= monto) Then
            monto = monto - retiro
            lstRetiros.Items.Add(retiro)
            Mostrar()
        Else
            MessageBox.Show("No se puede retirar una cantidad mayor al monto actual", "Gestion de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        desactivarControles()
        lstDeposito.Items.Clear()
        lstRetiros.Items.Clear()
        txtCliente.Clear()
        txtSaldo.Clear()
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
End Class
