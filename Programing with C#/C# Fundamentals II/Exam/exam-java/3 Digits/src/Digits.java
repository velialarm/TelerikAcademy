import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.Scanner;


public class Digits {

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
		Scanner sc = new Scanner(System.in);

	}

}