//
//  main.m
//  Matrix
//
//  Created by Venelin  on 10/25/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        
        int n;
        int m;
                
 //manual create matrix
        
        //Print matrix A
        n = 3;
        m = 3;
        int matrxA[3][3] = {
            {1,2,3},
            {8,9,4},
            {7,6,5}
        };
        
        for (int i = 0; i < n; i++) {
            NSMutableString *str = [[NSMutableString alloc]init];
            for (int y=0; y < m; y++) {
                [str appendString:[[NSString alloc]initWithFormat:@"Test %i ", matrxA[i][y]]];
            }
            NSLog(@"%@",str);
        }
        
        //Print  matrix B
        n = 4;
        m = 4;
        int matrixB[4][4] = {
            {1,2,3,4},
            {12,13,14,5},
            {11,16,15,6},
            {10,9,8,7}
        };

        for (int i = 0; i < n; i++) {
            NSMutableString *str = [[NSMutableString alloc]init];
            for (int y=0; y < m; y++) {
                [str appendString:[[NSString alloc]initWithFormat:@"%i ", matrixB[i][y]]];
            }
            NSLog(@"%@",str);
        }

        
        //Print matrix C
        //Variant 3
        n = 5;
        m = 5;
        int matrixC[5][5] = {
            {1,2,3,4,5},
            {16,17,18,19,6},
            {15,24,25,20,7},
            {14,23,22,21,8},
            {13,12,11,10,9}
        };
        
        for (int i = 0; i < n; i++) {
            NSMutableString *str = [[NSMutableString alloc]init];
            for (int y=0; y < m; y++) {
                [str appendString:[[NSString alloc]initWithFormat:@"%i ", matrixC[i][y]]];
            }
            NSLog(@"%@",str);
        }


            
    }
    return 0;
}

