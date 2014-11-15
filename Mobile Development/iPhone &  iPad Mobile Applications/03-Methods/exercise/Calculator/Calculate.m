//
//  Calculate.m
//  Calculator
//
//  Created by Venelin  on 10/25/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import "Calculate.h"

@implementation Calculate
- (id)init
{
    return [self initWithResult:[NSDecimalNumber decimalNumberWithString:@"0.00"]];
}

-(id) initWithResult:(NSDecimalNumber*)res{
    self = [super init];
    if (self) {
        _finalResult = res;
         NSLog(@"Init result with: %@", res);
    }
    return self;
}

-(NSDecimalNumber*)sum:(NSDecimalNumber *)value{
    return [self.finalResult decimalNumberByAdding:value];
}

-(NSDecimalNumber *)divide:(NSDecimalNumber *)value{
    return [self.finalResult decimalNumberByDividingBy:value];
}

-(NSDecimalNumber *)substract:(NSDecimalNumber *)value{
    return [self.finalResult decimalNumberBySubtracting:value];
}

-(NSDecimalNumber *)multiply:(NSDecimalNumber *)value{
    return [self.finalResult decimalNumberByMultiplyingBy:value];
}

@end
