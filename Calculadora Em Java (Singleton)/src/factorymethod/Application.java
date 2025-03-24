package factorymethod;

import java.util.Scanner;
import factorymethod.model.*;
import factorymethod.factory.*;

public class Application {

    public static void main(String[] args) {

        try (Scanner scanner = new Scanner(System.in)) {

            double a = 0, b = 0;
            String opcao = null;
            boolean continua = true;

            while (continua) {
                try {
                    System.out.print("Digite o primeiro número: ");
                    a = scanner.nextDouble();
                    System.out.print("Digite o segundo número: ");
                    b = scanner.nextDouble();
                    scanner.nextLine();
                    continua = false;
                } catch (Exception e) {
                    // Captura qualquer exceção que aconteça (por exemplo, se o usuário digitar uma string)
                    System.out.println("Entrada inválida! Por favor, digite um número válido.");
                    scanner.nextLine();
                }
            }

            System.out.println("Digite uma operação (Adicao, Subtracao, Multiplicacao ou Divisao, Sair para... sair (= ): ");
            opcao = scanner.nextLine();

            Operador operador = Factory.factory(opcao);

            if (operador == null){
                System.out.println("Nada Acontece, Feijoada!");
            }
            else {
                operador.calcular(a,b);
            }
        }
    }
}
