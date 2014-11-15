//
//  AccessDB.h
//  DatabaseAccess
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface AccessDB : NSObject

@property (strong, nonatomic) NSMutableArray* todota;

-(void)addTodo:(NSString*)msg withEndDate:(NSDate*)date;

-(NSMutableArray*) showTodotas;

@end
