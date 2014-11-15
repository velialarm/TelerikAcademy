//
//  Event.h
//  EventManager
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Event : NSObject
@property (strong, nonatomic) NSString* title;
@property (strong, nonatomic) NSString* category;
@property (strong, nonatomic) NSString* description;
@property (strong, nonatomic) NSDate* date;
@property (strong, nonatomic) NSArray* guests;

@end
