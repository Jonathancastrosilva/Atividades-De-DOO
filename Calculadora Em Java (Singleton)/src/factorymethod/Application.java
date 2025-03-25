package factorymethod;

import factorymethod.factory.*;
import factorymethod.model.*;

import java.util.InputMismatchException;
import java.util.Scanner;

public class Application {

    public static void main(String[] args) {

        Scanner s = new Scanner(System.in);
        Factory factory = Factory.getInstance();

        boolean continua = true;

        while (continua) {

            try {

                System.out.print("Digite o primeiro número: ");
                double a = s.nextDouble();
                System.out.print("Digite o segundo número: ");
                double b = s.nextDouble();
                s.nextLine();
                System.out.println("Digite uma operação (Adicao, Subtracao, Multiplicacao ou Divisao, Sair para... sair (= ): ");
                String opcao = s.nextLine();
                opcao = opcao.substring(0, 1).toUpperCase() + opcao.substring(1).toLowerCase();

                if (opcao.equals("Sair")){
                    continua = false;
                }

                else{
                    Operador operador = Factory.factory(opcao);

                    if (operador == null){
                        System.out.println("Nome De Operação Incorreto");
                    }
                    else {
                        operador.calcular(a,b);
                    }
                }

            } catch (InputMismatchException e) {
                // Captura qualquer exceção que aconteça (por exemplo, se o usuário digitar uma string)
                System.out.println("Entrada inválida! Por favor, digite uma entrada válida.");
                s.nextLine();

            } catch (ArithmeticException e){
                System.out.println("Matematica tem regra...");
            }
        }
    }
}
