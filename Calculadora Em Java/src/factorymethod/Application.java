package factorymethod;

import java.util.Scanner;
import factorymethod.model.*;
import factorymethod.factory.*;

public class Application {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double a = 0, b = 0;
        int opcao = 0;
        boolean continua1 = true, continua2 = true, continua3 = true;

        while (continua1) {
            try {
                System.out.print("Digite o primeiro número: ");
                a = scanner.nextDouble();
                continua1 = false;
            } catch (Exception e) {
                // Captura qualquer exceção que aconteça (por exemplo, se o usuário digitar uma string)
                System.out.println("Entrada inválida! Por favor, digite um número válido.");
                scanner.nextLine();
            }
        }

        while (continua2){
            try {
                System.out.print("Digite o segundo número: ");
                b = scanner.nextDouble();
                scanner.nextLine();
                continua2 = false;
            } catch (Exception e) {
                // Captura qualquer exceção que aconteça (por exemplo, se o usuário digitar uma string)
                System.out.println("Entrada inválida! Por favor, digite um número válido.");
                scanner.nextLine();
            }
        }

        while (continua3){
            try {
                System.out.println("Digite uma operação (1 = Adicao, 2 = Subtraçao, 3 = Multiplicação, 4 = Divisão, Qualquer outra coisa = Nada Acontece (= ): ");
                opcao = scanner.nextInt();
                continua3 = false;
            } catch (Exception e) {
                // Captura qualquer exceção que aconteça (por exemplo, se o usuário digitar uma string)
                System.out.println("Entrada inválida! Por favor, digite um número inteiro.");
                scanner.nextLine();
            }
        }

        if (opcao == 1){
            Operador operador = Factory.factory("Adicao");
            operador.calcular(a,b);
        }
        if (opcao == 2){
            Operador operador = Factory.factory("Subtracao");
            operador.calcular(a,b);
        }
        if (opcao == 3){
            Operador operador = Factory.factory("Multiplicacao");
            operador.calcular(a,b);
        }
        if (opcao == 4){
            Operador operador = Factory.factory("Divisao");
            operador.calcular(a,b);
        }
    }
}
