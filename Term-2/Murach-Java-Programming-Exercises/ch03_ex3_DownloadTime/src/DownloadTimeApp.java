/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package ch03_ex3_downloadtime;

import java.util.Scanner;

/**
 *
 * @author Daniel
 */
public class DownloadTimeApp {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        double fileSize = 0;
        double downloadSpeed = 0;
        String choice = "y";
        Scanner sc = new Scanner(System.in);
        
        // input and output
        System.out.println("Welcome to the Download Time Estimator");
        
        while (choice.equalsIgnoreCase("y")) {
        
            System.out.print("\nEnter file size (MB): ");
            fileSize = sc.nextDouble();
            System.out.print("Enter download speed (MB/sec): ");
            downloadSpeed = sc.nextDouble();

            // time calculation
            double seconds = Math.round(fileSize * downloadSpeed);      
            double hours = seconds / 3600;
            seconds %= 3600;
            double minutes = seconds / 60;
            seconds %= 60;


            System.out.println("\nThis download will take approximately: " 
                    + (int)hours + " hours " + (int)minutes + " minutes " 
                    + (int)seconds + " seconds\n");
            
            while (!choice.equalsIgnoreCase("n")) {
                System.out.print("Continue? (y/n): ");
                choice = sc.next();
                if(choice.equalsIgnoreCase("y"))
                    break;
            } // end of unknown choice while loop
       
        } // end of yes choice while loop
        
    }
    
}
