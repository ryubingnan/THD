/*
 * @description: utils
 * @author: nike.x.mao
 * @LastEditors: nike.x.mao
 * @LastEditTime:2021-02-03 14:26:46
 */
function trim (val) {
  if (isObject(val)) {
    if (isArray(val)) {
      return val.map(item => trim(item))
    } else {
      const obj = { ...val }
      Object.keys(val).forEach(key => {
        obj[key] = trim(obj[key])
      })
      return obj
    }
  } else if (isString(val)) {
    return val.trim()
  } else {
    return val
  }
}

/**
 * 验证数字输入
 * @param value 数据
 * @param integer 整数几位 要求大于0
 * @param decimal 小数几位 要求大于0
 * validationNumber(111.11,3,2) => true 要求最多3位整数，必须2位小数
 */
function validationNumber (value, integer, decimal) {
  if (value.toString().trim().length === 1 && Number(value) === 0) {
    return true
  }

  const pattern = new RegExp('^((?!0)\\d{1,' + integer + '}|(0\\.|[1-9]\\d*\\.)\\d{1,' + decimal + '})$')
  return pattern.test(value)
}

// 字段格式映射关系
const formatNumberDisplayMapping = [
  // 2位小数百分号
  { fields: ['DeviationRate', 'AvgDeviationRate'], fractionDigits: 2, percentage: true },
  // 整数无小数位
  { fields: ['WeightCount', 'DataCount'], fractionDigits: 0 },
  // 保留2位小数
  { fields: ['NotTaxAmount', 'Amount'], fractionDigits: 2, moreThanTenThousand: 2 },
  // 保留3位小数
  {
    fields: ['AvgTareWeight', 'MinTareWeight', 'MaxTareWeight', 'ExpectedValue',
      'RealValue', 'ActualDeductedValue', 'ActualValue', 'Weight', 'DeductedWeight', 'ExpectedWeight', 'ActualWeight'],
    fractionDigits: 3
  },
  // 保留4位小数
  { fields: ['ActualValueOfDay', 'WeightOfDay', 'NotTaxUnitPrice', 'UnitPrice', 'ActualQuantity'], fractionDigits: 4, moreThanTenThousand: 4 }
]

/**
 * 格式化展示数字
 * @param data 数据
 * @param options
 * defaultOptions = {
    // 保留小数位数
    fractionDigits: 2,
    // 大于万元时保留小数位数
    moreThanTenThousand: 3,
    // 是否显示百分比
    percentage: false,
    // 整数是否显示小数位
    wholeNumberShowFloat: true,
  }
 formatNumber(999999, { fractionDigits: 2, moreThanTenThousand: 5, wholeNumberShowFloat: true })) => 99.99990 万
 formatNumber(999, { fractionDigits: 2, moreThanTenThousand: 5, wholeNumberShowFloat: true })) => 999.00
 */
function formatNumber (data, options) {
  let defaultOptions = {
    // 保留小数位数
    fractionDigits: 3,
    // 大于万元时保留小数位数
    moreThanTenThousand: 3,
    // 是否显示百分比
    percentage: false,
    // 整数是否显示小数位
    wholeNumberShowFloat: true,
    unitVal: 10000,
    unit: '万'
  }
  const unitVal = defaultOptions.unitVal
  if (isObject(options)) {
    defaultOptions = { ...defaultOptions, ...options }
  } else if (isInteger(options)) {
    defaultOptions.fractionDigits = options
  }
  // null undefined 0 '0'
  if (!data || Number(data) === 0) {
    return defaultOptions.percentage ? '0.00%' : '0'
  }

  let flag = ''
  // 大于10000的小数位设置
  if (data > unitVal) {
    defaultOptions.fractionDigits = defaultOptions.moreThanTenThousand
  }
  // 整数是否显示小数位
  if (!defaultOptions.wholeNumberShowFloat && (data % unitVal === 0 || (data < unitVal && isInteger(data)))) {
    defaultOptions.fractionDigits = 0
  }

  for (let i = 0; i < defaultOptions.fractionDigits; i++) {
    flag += '0'
  }

  flag += defaultOptions.percentage ? '%' : ' W'
  return numerify(data, `0.${flag}`)
}

/**
 * 格式化展示数字
 * @param data 数字
 * @param fractionDigits 默认2位
 * @returns value
 */
function formatToPercentage (data, fractionDigits = 2) {
  let flag = ''
  for (let i = 0; i < fractionDigits; i++) {
    flag += '0'
  }
  return numerify(data, `0.${flag}%`)
}

/**
 * 格式化展示数字
 * @param fieldName 字段名称 需配置映射关系
 * @param fieldValue 字段值
 * @returns value
 */
function formatNumberDisplay (fieldName, fieldValue) {
  try {
    const found = formatNumberDisplayMapping.filter(m => {
      return m.fields.includes(fieldName)
    })
    // js 空数组直接判断为true
    if (found && found.length === 0) {
      console.warn(`not config fieldName:${fieldName} format mapping.`)
      return fieldValue
    }
    // const { fractionDigits, percentage } = found[0]
    return formatNumber(fieldValue, found[0])
  } catch (e) {
    console.error('format number error:', e)
  }
}

function tableColumnFormatter (row, column, cellValue) {
  return formatNumberDisplay(column.property, cellValue)
}

function deepClone (obj, cache = []) {
    if (obj === null || typeof obj !== "object") {
        return obj
    }
    const hit = cache.find(c => c.original === obj)
    if (hit) {
        return hit.copy
    }
    const copy = Array.isArray(obj) ? [] : {}
    cache.push[{
        original: obj,
        copy
    }]
    Object.keys(obj).forEach(key => {
        copy[key] = deepClone(obj[key], cache)
    })
    return copy
}
