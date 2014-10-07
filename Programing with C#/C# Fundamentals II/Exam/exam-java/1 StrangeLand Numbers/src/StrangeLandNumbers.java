import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class StrangeLandNumbers {

	private static Map<String, Integer> numbers = new HashMap<>();

	public static void main(String[] args) {
		String dir = System.getProperty("user.dir");
		String fileName = dir + "\\input.txt";
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

		InitDic();

		String line = sc.nextLine();

		List<Integer> resNum = new ArrayList<Integer>();
		StringBuilder buffer = new StringBuilder();
		for (int i = 0; i < line.length(); i++) {
			String curChar = line.substring(i, i+1);
			buffer.append(curChar);
			if (numbers.containsKey(buffer.toString())) {
				int n = numbers.get(buffer.toString());
				resNum.add(n);
				buffer = new StringBuilder();
			}

		}
		BigInteger sum = BigInteger.valueOf(0);
		for (int i = 0; i < resNum.size(); i++) {
			BigInteger stepen = Pow(resNum.size() - i - 1);
			BigInteger fnum = BigInteger.valueOf((long) resNum.get(i));
			sum = sum.add(fnum.multiply(stepen));
		}
		System.out.println(sum);
	}

	private static BigInteger Pow(int power) {
		BigInteger result = BigInteger.valueOf(1);
		for (int i = 0; i < power; i++) {
			result = result.multiply(BigInteger.valueOf(7));
		}
		return result;
	}

	private static void InitDic() {
		numbers.put("f", 0);
		numbers.put("bIN", 1);
		numbers.put("oBJEC", 2);
		numbers.put("mNTRAVL", 3);
		numbers.put("lPVKNQ", 4);
		numbers.put("pNWE", 5);
		numbers.put("hT", 6);
	}

}
