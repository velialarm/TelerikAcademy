import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.math.BigInteger;
import java.util.Scanner;


public class TwoGirlsOnePath {

	public static void main(String[] args) {
		String dir = System.getProperty("user.dir");
		String fileName = dir + "\\input.txt";
		// System.out.println(fileName);
		File f = new File(fileName);
		if (f.exists()) {
			try {
				System.setIn(new BufferedInputStream(new FileInputStream(
						fileName)));
				System.setIn(new FileInputStream(fileName));
			} catch (FileNotFoundException e) {
				System.out.println(e.getMessage());
			}
		}
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		String line = sc.nextLine();

		String[] buff = line.split(" ");
        BigInteger[] flowers = new BigInteger[buff.length];
        for (int i = 0; i < buff.length; i++)
        {
            flowers[i] = BigInteger.valueOf(Long.parseLong(buff[i]));
        }
        int posPlayer1 = 0;
        int posPlayer2 = flowers.length-1;
        BigInteger maxMatrixLenght = BigInteger.valueOf(flowers.length-1);
        BigInteger sumPlayer1 = BigInteger.ZERO ;
        BigInteger sumPlayer2 = BigInteger.ZERO;
        String win = "";
        while (true)
        {
            // TODO position check 
            BigInteger curFlowerPlayer1 = flowers[posPlayer1];
            BigInteger curFlowerPlayer2 = flowers[posPlayer2];
            sumPlayer1 = sumPlayer1.add(curFlowerPlayer1); //result Molly
            sumPlayer2 = sumPlayer2.add(curFlowerPlayer2);  //result Dolly
            if (curFlowerPlayer1.equals(BigInteger.ZERO) && curFlowerPlayer2.equals(BigInteger.ZERO))
            {
                 win = "Draw";
                 break;
            }else if (curFlowerPlayer1.equals(BigInteger.ZERO))
            {
                win = "Dolly";
                break;
            }else if (curFlowerPlayer2.equals(BigInteger.ZERO))
            {
                win = "Molly";
                break;
            }
          
            flowers[posPlayer1] = BigInteger.ZERO ;
            flowers[posPlayer2] = BigInteger.ZERO ;
            
            if (BigInteger.valueOf(posPlayer1).add(curFlowerPlayer1).compareTo(curFlowerPlayer1) > 0)
            {
                posPlayer1 =  BigInteger.valueOf(posPlayer1).add(curFlowerPlayer1).remainder(maxMatrixLenght).intValue()-1;
            }
            else
            {
                posPlayer1 =  BigInteger.valueOf(posPlayer1).add(curFlowerPlayer1).intValue();
                
            }
            
            if (BigInteger.valueOf(posPlayer2).subtract(curFlowerPlayer2).compareTo(BigInteger.ZERO) < 0)
            {

                posPlayer2 = BigInteger.valueOf(posPlayer2).add(curFlowerPlayer2).remainder(maxMatrixLenght).intValue();
            }
            else
            {
                posPlayer2 = BigInteger.valueOf(posPlayer2).subtract(curFlowerPlayer2).intValue();
            }
        }
        
        System.out.println(win);
        System.out.format("%s %s",sumPlayer1,sumPlayer2);
	}

}
