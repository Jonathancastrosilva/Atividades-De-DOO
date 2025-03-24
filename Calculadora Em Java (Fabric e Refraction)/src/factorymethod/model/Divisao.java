package factorymethod.model;

public class Divisao implements Operador  {
    @Override
    public void calcular(double a, double b) {
        if (b == 0) {
            System.out.println("Dividir por 0... IMPOSSIVEL");
        }
        else{
            System.out.println(a + " / " + b + " = " + (a / b));
        }

    }
}
