package factorymethod.factory;

import factorymethod.model.Operador;

public class Factory {
    
    public static Operador factory(String tipo){
        
        Object classeInstanciada = null;
        
        try {
            classeInstanciada = Class.forName("factorymethod.model."+tipo).newInstance();

        } catch (InstantiationException e) {
            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        
        return (Operador) classeInstanciada;

    }
}
