//
//  main.m
//  Calculator
//
//  Created by Venelin  on 10/25/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Calculate.h"

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        
        NSDecimalNumber *result;
        
        //init calculator and save current result
        NSDecimalNumber *startValue = [NSDecimalNumber decimalNumberWithString:@"10.00"];
        Calculate *calc = [[Calculate alloc] initWithResult:startValue];
        
        //Add value to the result
        result = [calc sum:[NSDecimalNumber decimalNumberWithString:@"25.24"]];
        NSLog(@"Sum result is: %@", result);
        
        //Divide the result by given devider
        result = [calc divide:[NSDecimalNumber decimalNumberWithString:@"2"]];
         NSLog(@"Divide result is: %@", result);
        
        //Substract va value from the result
        result = [calc substract:[NSDecimalNumber decimalNumberWithString:@"2"]];
         NSLog(@"Substract result is: %@", result);
        
        //multiply the result a given value
        result = [calc multiply:[NSDecimalNumber decimalNumberWithString:@"3.2"]];
         NSLog(@"Multiply result is: %@", result);
        
        
    }
    return 0;
}

