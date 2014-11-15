//
//  Calculate.h
//  Calculator
//
//  Created by Venelin  on 10/25/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Calculate : NSObject

@property NSDecimalNumber *finalResult;

-(Calculate*) initWithResult:value;

-(NSDecimalNumber*) sum:(NSDecimalNumber*)value;

-(NSDecimalNumber*)divide: (NSDecimalNumber*)value;

-(NSDecimalNumber*)substract: (NSDecimalNumber*)value;

-(NSDecimalNumber*)multiply: (NSDecimalNumber*)value;

@end
