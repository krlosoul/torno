public class Tarjetas{

    //attr base
    public int nro_tarjeta { get; set; } 
    public int valor { get; set; } 
    public datetime ultimo_acceso { get; set; } //fecha
    public int ultimo_valor_pagado { get; set; } 
    public string estación { get; set; } 
    public int torno { get; set; } 
    //attr int
    public datetime hora_entrada { get; set; } 
    public string estacion_origen { get; set; } 
    //attr out
    public datetime hora_salida { get; set; } 
    public string estacion_destino { get; set; }

    public void SetTarjeta(Torno torno){
        //como se desconoce el metodo de almacenamiento de la tarjeta, se llamara un metodo cualquiera
        this.GrabarTarjeta();
    }

    // se llama siempre la misma tarjeta, ya que se desconoce el metodo de lectura
    public Tarjetas GetDatoTarjeta()
    {
        Tarjetas t = new Tarjetas();

        t.nro_tarjeta = 1;
        t.valor = 150000;
        t.ultimo_acceso = "2020-08-15";
        t.ultimo_valor_pagado = 1500 ;
        t.estación = "SANTA MONICA";//donde se adquirio la tarjeta
        t.torno = 7 ;//donde se adquirio la tarjeta
        
        return t;
    }

    private void EntradaTorno(Tortno torno)
    {
        Tarjetas t = this.GetDatoTarjeta();
        t.hora_entrada = torno.fecha_actual;//obtiene la hora y fecha actual del torno
        t.estacion_origen = torno.estacion; //nombre de estacion
        t.ultimo_acceso = torno.fecha_actual;
        this.GrabarTarjeta(t);
    }

    private void SalidaTorno(Tortno torno)
    {
        Tarjetas t = this.GetDatoTarjeta();
        t.hora_salida = torno.fecha_actual;//obtiene la hora y fecha actual del torno
        t.estacion_destino = torno.estacion; //nombre de estacion
        t.ultimo_acceso = torno.fecha_actual;

        //calcular el tiempo recorrido
        DateTime fecha1 = Convert.ToDatetime(t.hora_entrada.ToString("HH:mm:ss")));
        DateTime fecha2 = Convert.ToDatetime(t.hora_salida.ToString("HH:mm:ss")));
        double tiempo = fecha2.Subtract(fecha1).TotalHours;
        
        double velocidad = 60; //el recorrido es en promedio de 60 km/h
        double distancia = velocidad * tiempo;
        
        double cobro = 100; //se cobra 100 pesos por kilomero recorrido
        double valor_cobro = distancia * cobro;

        if(valor_cobro > t.valor){
            this.MostrarMensaje("Saldo insuficiente");
            return;//termina sin almacenar la informacion
        }

        t.valor = t.valor - valor_cobro;
        t.ultimo_acceso = torno.fecha_actual;//obtiene la hora y fecha actual del torno
        t.ultimo_valor_pagado =  valor_cobro;

        this.GrabarTarjeta(t);
    }

    //entrar a estacion (t == torno)
    this.EntradaTorno(t);

    //salir de estacion (t == torno)
    this.SalidaTorno(t);


}
